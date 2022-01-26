﻿using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Anita
{
    public enum CurrentViewType
    {
        UI,
        Game,
        DialogueHidden,
        InTransition,
        Alert
    }

    [RequireComponent(typeof(ScreenCapturer))]
    public class ViewManager : MonoBehaviour
    {
        [HideInInspector] public AnitaAnimation uiAnimation;
        [HideInInspector] public ScreenCapturer screenCapturer;

        public RawImage transitionGhost;
        public GameObject transitionInputBlocker;
        public AudioSource uiAudioSource;

        // Pause some animations and audios when switching the view
        public List<AnitaAnimation> animationsToPause;
        public List<AudioController> audiosToPause;

        private GameController gameController;

        // animationsToPause + gameController.PerDialogueAnimation + gameController.PersistAnimation
        private IEnumerable<AnitaAnimation> allAnimationsToPause => GetAllAnimationsToPause();

        private IEnumerable<AnitaAnimation> GetAllAnimationsToPause()
        {
            var hasPerDialogue = false;
            var hasPersist = false;
            foreach (var anim in animationsToPause)
            {
                if (anim == gameController.PerDialogueAnimation)
                {
                    hasPerDialogue = true;
                }

                if (anim == gameController.PersistAnimation)
                {
                    hasPersist = true;
                }

                yield return anim;
            }

            if (!hasPersist)
            {
                yield return gameController.PersistAnimation;
            }

            if (!hasPerDialogue)
            {
                yield return gameController.PerDialogueAnimation;
            }
        }

        private readonly Dictionary<Type, ViewControllerBase> controllers = new Dictionary<Type, ViewControllerBase>();
        private readonly Type[] overlayViewControllers = {typeof(NotificationViewController)};

        public GameObject dialoguePanel => GetController<DialogueBoxController>().myPanel;

        public GameObject titlePanel => GetController<TitleController>().myPanel;

        private void Awake()
        {
            currentView = CurrentViewType.UI;
            gameController = Utils.FindAnitaGameController();
            uiAnimation = gameController.transform.Find("AnitaAnimation/UI").GetComponent<AnitaAnimation>();
            screenCapturer = GetComponent<ScreenCapturer>();
            this.RuntimeAssert(screenCapturer != null, "Missing ScreenCapturer.");
        }

        public void SetController(ViewControllerBase controller)
        {
            controllers[controller.GetType()] = controller;
        }

        public void UnsetController(ViewControllerBase controller)
        {
            controllers.Remove(controller.GetType());
        }

        public T GetController<T>() where T : ViewControllerBase
        {
            return controllers[typeof(T)] as T;
        }

        public CurrentViewType currentView { get; private set; }

        public void UpdateView(bool isInTransition)
        {
            var newView = isInTransition ? CurrentViewType.InTransition : QueryCurrentView();
            transitionInputBlocker.SetActive(isInTransition);
            if (currentView == newView)
            {
                return;
            }

            if (newView == CurrentViewType.Game && currentView != CurrentViewType.Game)
            {
                // Resume all animations
                foreach (var anim in allAnimationsToPause)
                {
                    anim.Play();
                }

                foreach (var ac in audiosToPause)
                {
                    ac.UnPause();
                }
            }
            else if (currentView == CurrentViewType.Game && newView != CurrentViewType.Game)
            {
                // Pause all animations
                foreach (var anim in allAnimationsToPause)
                {
                    anim.Pause();
                }

                foreach (var ac in audiosToPause)
                {
                    ac.Pause();
                }
            }

            currentView = newView;
            // Debug.LogFormat("Current view: {0}", CurrentView);
        }

        public void SwitchView<FromController, TargetController>(Action onFinish = null)
            where FromController : ViewControllerBase
            where TargetController : ViewControllerBase
        {
            GetController<FromController>().SwitchView<TargetController>(onFinish);
        }

        public void StopAllAnimations()
        {
            foreach (var anim in allAnimationsToPause)
            {
                anim.Stop();
            }
        }

        private CurrentViewType QueryCurrentView()
        {
            if (transitionGhost.gameObject.activeSelf)
            {
                return CurrentViewType.InTransition;
            }

            if (controllers[typeof(AlertController)].myPanel.activeSelf)
            {
                return CurrentViewType.Alert;
            }

            var activeNonGameControllerCount = controllers.Values.Count(c =>
                overlayViewControllers.All(t => !t.IsInstanceOfType(c)) &&
                !(c is DialogueBoxController) &&
                c.myPanel.activeSelf
            );
            if (activeNonGameControllerCount == 0)
            {
                if (dialoguePanel.activeSelf)
                {
                    return CurrentViewType.Game;
                }
                else
                {
                    return CurrentViewType.DialogueHidden;
                }
            }

            return CurrentViewType.UI;
        }

        public void TryPlaySound(AudioClip clip)
        {
            if (uiAudioSource != null && clip != null)
            {
                uiAudioSource.clip = clip;
                uiAudioSource.Play();
            }
        }

        public void TryStopSound()
        {
            if (uiAudioSource != null)
            {
                uiAudioSource.Stop();
            }
        }
    }

    public static class ViewHelper
    {
        public static void SwitchView<TargetController>(this ViewControllerBase controller, Action onFinish = null)
            where TargetController : ViewControllerBase
        {
            controller.Hide(() =>
                controller.viewManager.GetController<TargetController>().Show(onFinish)
            );
        }
    }
}