﻿using UnityEngine;
using UnityEngine.EventSystems;

namespace Nova
{
    public partial class DialogueBoxController
    {
        private const string AbortAnimationFirstShownKey = ConfigViewController.FirstShownKeyPrefix + "AbortAnimation";
        private const int HintAbortAnimationClicks = 10;

        private bool _fastForwardHotKeyHolding;

        private bool fastForwardHotKeyHolding
        {
            get => _fastForwardHotKeyHolding;
            set
            {
                if (_fastForwardHotKeyHolding == value) return;
                _fastForwardHotKeyHolding = value;
                state = value ? DialogueBoxState.FastForward : DialogueBoxState.Normal;
            }
        }

        private void HandleShortcutInGameView()
        {
            if (inputMapper.GetKeyUp(AbstractKey.Auto))
            {
                state = DialogueBoxState.Auto;
            }

            if (inputMapper.GetKeyUp(AbstractKey.Save))
            {
                viewManager.GetController<SaveViewController>().ShowSave();
            }

            if (inputMapper.GetKeyUp(AbstractKey.Load))
            {
                viewManager.GetController<SaveViewController>().ShowLoad();
            }

            if (inputMapper.GetKeyUp(AbstractKey.QuickSave))
            {
                viewManager.GetController<SaveViewController>().QuickSaveBookmark();
            }

            if (inputMapper.GetKeyUp(AbstractKey.QuickLoad))
            {
                viewManager.GetController<SaveViewController>().QuickLoadBookmark();
            }

            if (inputMapper.GetKeyUp(AbstractKey.ToggleDialogue))
            {
                Hide();
            }

            if (inputMapper.GetKeyUp(AbstractKey.StepForward))
            {
                ClickForward();
            }

            if (inputMapper.GetKeyUp(AbstractKey.ShowLog))
            {
                viewManager.GetController<LogController>().Show();
            }

            fastForwardHotKeyHolding = inputMapper.GetKey(AbstractKey.FastForward);
        }

        private void HandleShortcutWhenDialogueHidden()
        {
            if (inputMapper.GetKeyUp(AbstractKey.ToggleDialogue))
            {
                Show();
            }
        }

#if UNITY_EDITOR

        private void HandleEditorOnlyShortcut()
        {
            if (viewManager.currentView == CurrentViewType.Game)
            {
                if (inputMapper.GetKeyUp(AbstractKey.EditorBackward))
                {
                    state = DialogueBoxState.Normal;
                    try
                    {
                        gameState.SeekBackStep(1, out var nodeName, out var dialogueIndex);
                        gameState.MoveBackTo(nodeName, dialogueIndex, 0UL);
                    }
                    catch
                    {
                        // TODO: handle exceptions
                    }
                }

                if (inputMapper.GetKeyUp(AbstractKey.EditorBeginChapter))
                {
                    JumpChapter(0);
                }

                if (inputMapper.GetKeyUp(AbstractKey.EditorPreviousChapter))
                {
                    JumpChapter(-1);
                }

                if (inputMapper.GetKeyUp(AbstractKey.EditorNextChapter))
                {
                    JumpChapter(1);
                }
            }
        }

#endif

        private void HandleShortcut()
        {
            if (buttonRingTrigger.buttonShowing)
            {
                if (inputMapper.GetKeyUp(AbstractKey.LeaveView))
                {
                    buttonRingTrigger.Hide(false);
                }
            }
            else
            {
                if (viewManager.currentView == CurrentViewType.Game)
                {
                    HandleShortcutInGameView();
                }

                if (viewManager.currentView == CurrentViewType.DialogueHidden)
                {
                    HandleShortcutWhenDialogueHidden();
                }
            }

#if UNITY_EDITOR
            HandleEditorOnlyShortcut();
#endif
        }

        [HideInInspector] public RightButtonAction rightButtonAction;

        private bool skipNextTouch = false;
        private bool skipTouchOnPointerUp = false;

        public void OnPointerUp(PointerEventData eventData)
        {
            if (gameController.inputDisabled)
            {
                // Touch finger
                if (eventData.pointerId >= 0)
                {
                    ClickForward();
                }

                return;
            }

            var view = viewManager.currentView;
            if (view == CurrentViewType.DialogueHidden)
            {
                Show();
                return;
            }
            else if (view != CurrentViewType.Game)
            {
                return;
            }

            if (buttonRingTrigger.buttonShowing)
            {
                buttonRingTrigger.Hide(!buttonRingTrigger.holdOpen || eventData.pointerId != -2);
                return;
            }

            // Mouse right button
            if (eventData.pointerId == -2 || Input.touchCount == 2)
            {
                if (!buttonRingTrigger.buttonShowing)
                {
                    buttonRingTrigger.NoShowIfMouseMoved();
                    if (rightButtonAction == RightButtonAction.HideDialoguePanel)
                    {
                        Hide();
                    }
                    else if (rightButtonAction == RightButtonAction.ShowButtonRing)
                    {
                        float r = buttonRingTrigger.sectorRadius * RealScreen.fWidth / 1920 * 0.5f;
                        if (RealInput.mousePosition.x > r && RealInput.mousePosition.x < RealScreen.width - r &&
                            RealInput.mousePosition.y > r && RealInput.mousePosition.y < RealScreen.height - r)
                        {
                            buttonRingTrigger.Show(true);
                        }
                    }
                }
                else if (!buttonRingTrigger.holdOpen)
                {
                    buttonRingTrigger.Hide(true);
                }

                if (Input.touchCount == 2)
                {
                    skipNextTouch = true;
                }
            }
            else
            {
                // Touch finger
                // (consequent touch will be converted to 1 / 2 / ... due to unknown reason)
                if (eventData.pointerId >= 0)
                {
                    if (!buttonRingTrigger.buttonShowing && !skipNextTouch && !skipTouchOnPointerUp)
                    {
                        ClickForward();
                    }

                    buttonRingTrigger.Hide(true);
                }

                skipNextTouch = false;
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (gameController.inputDisabled)
            {
                // Mouse left button
                if (eventData.pointerId == -1)
                {
                    ClickForward();
                }

                return;
            }

            if (viewManager.currentView != CurrentViewType.Game)
            {
                return;
            }

            if (buttonRingTrigger.buttonShowing)
            {
                return;
            }

            // Stop auto/fast forward on any button or torch
            state = DialogueBoxState.Normal;

            // Handle hyperlinks on any button or torch
            Camera uiCamera = UICameraHelper.Active;
            foreach (var dec in dialogueText.dialogueEntryControllers)
            {
                string link = dec.FindIntersectingLink(RealInput.mousePosition, uiCamera);
                if (link != "")
                {
                    Application.OpenURL(link);
                    skipTouchOnPointerUp = true;
                    return;
                }
            }

            skipTouchOnPointerUp = false;

            // Mouse left button
            if (eventData.pointerId == -1)
            {
                ClickForward();
            }

            // Mouse right button or touch finger
            if (eventData.pointerId == -2 || eventData.pointerId >= 0)
            {
                float r = buttonRingTrigger.sectorRadius * RealScreen.fWidth / 1920 * 0.5f;
                if (RealInput.mousePosition.x > r && RealInput.mousePosition.x < RealScreen.width - r &&
                    RealInput.mousePosition.y > r && RealInput.mousePosition.y < RealScreen.height - r)
                {
                    buttonRingTrigger.ShowIfMouseMoved();
                }
            }
        }

        private void HandleInput()
        {
            if (Input.mousePresent && (
                    RealInput.mousePosition.x < 0 || RealInput.mousePosition.x > RealScreen.width ||
                    RealInput.mousePosition.y < 0 || RealInput.mousePosition.y > RealScreen.height)
            )
            {
                // Ignore input when mouse is outside of the game window
                return;
            }

            if (buttonRingTrigger.buttonShowing)
            {
                return;
            }

            if (viewManager.currentView == CurrentViewType.Game)
            {
                float scroll = Input.mouseScrollDelta.y;
                if (scroll > 0)
                {
                    state = DialogueBoxState.Normal;
                    logController.Show();
                }
                else if (scroll < 0)
                {
                    ClickForward();
                }
            }
        }

        [HideInInspector] public bool canClickForward = true;
        [HideInInspector] public bool canAbortAnimation = true;
        [HideInInspector] public bool scriptCanAbortAnimation = true;
        [HideInInspector] public bool onlyFastForwardRead = true;

        public void ClickForward()
        {
            if (!canClickForward)
            {
                return;
            }

            state = DialogueBoxState.Normal;

            bool isAnimating = NovaAnimation.IsPlayingAny(AnimationType.PerDialogue);
            bool textIsAnimating = textAnimation.isPlaying;

            if (!isAnimating && !textIsAnimating)
            {
                NextPageOrStep();
                return;
            }

            // When user clicks, text animation should stop, independent of canAbortAnimation
            if (textIsAnimating)
            {
                textAnimation.Stop();
            }

            if (!scriptCanAbortAnimation)
            {
                return;
            }

            if (!canAbortAnimation)
            {
                int clicks = configManager.GetInt(AbortAnimationFirstShownKey);
                if (clicks < HintAbortAnimationClicks)
                {
                    configManager.SetInt(AbortAnimationFirstShownKey, clicks + 1);
                }
                else if (clicks == HintAbortAnimationClicks)
                {
                    Alert.Show(I18n.__("dialogue.hint.clickstopchoreo"));
                    configManager.SetInt(AbortAnimationFirstShownKey, clicks + 1);
                }

                return;
            }

            if (isAnimating)
            {
                NovaAnimation.StopAll(AnimationType.PerDialogue);

                dialogueFinished.SetActive(true);
            }
        }
    }
}