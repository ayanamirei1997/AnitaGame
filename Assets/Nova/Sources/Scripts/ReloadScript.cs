﻿using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Nova
{
    public class ReloadScript : MonoBehaviour
    {
        [SerializeField] private GameObject characters;
        [SerializeField] private SoundController soundController;
        [SerializeField] private ViewManager viewManager;

        private GameState gameState;
        private InputMapper inputMapper;
        private List<CharacterController> characterControllers;
        private ulong currentNodeInitialVariablesHash;

        private void Start()
        {
            var gameController = Utils.FindNovaGameController();
            gameState = gameController.GameState;
            inputMapper = gameController.InputMapper;

            if (characters != null)
            {
                characterControllers = characters.GetComponentsInChildren<CharacterController>().ToList();
            }

            if (!Application.isEditor) return;

            currentNodeInitialVariablesHash = 0UL;
            gameState.NodeChanged += OnNodeChanged;
        }

        private void OnDestroy()
        {
            gameState.NodeChanged -= OnNodeChanged;
        }

        private void OnNodeChanged(NodeChangedData nodeChangedData)
        {
            currentNodeInitialVariablesHash = gameState.variables.hash;
        }

        private void Update()
        {
            if (viewManager.currentView != CurrentViewType.Game)
            {
                return;
            }

            if (inputMapper.GetKeyUp(AbstractKey.EditorReloadScripts))
            {
                ReloadScripts();
            }

            if (inputMapper.GetKeyUp(AbstractKey.EditorRerunAction))
            {
                RerunAction();
            }
        }

        private void SuppressSound(bool v)
        {
            if (characterControllers != null)
            {
                foreach (var characterController in characterControllers)
                {
                    characterController.suppressSound = v;
                }
            }

            if (soundController != null)
            {
                soundController.suppressSound = v;
            }
        }

        private void ReloadScripts()
        {
            NovaAnimation.StopAll();
            var currentNode = gameState.currentNode;
            var currentIndex = gameState.currentIndex;
            SuppressSound(true);
            gameState.MoveBackTo(currentNode.name, 0, currentNodeInitialVariablesHash, clearFuture: true);
            gameState.ReloadScripts();

            // step back to current index
            for (var i = 0; i < currentIndex - 1; i++)
            {
                NovaAnimation.StopAll(AnimationType.PerDialogue | AnimationType.Text);
                gameState.Step();
            }

            NovaAnimation.StopAll(AnimationType.PerDialogue | AnimationType.Text);
            SuppressSound(false); // only the last step can play sound
            gameState.Step();
        }

        private void RerunAction()
        {
            gameState.currentNode.GetDialogueEntryAt(gameState.currentIndex).ExecuteAction();
        }
    }
}