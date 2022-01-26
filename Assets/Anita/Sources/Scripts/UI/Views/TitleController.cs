﻿using System;
using System.Linq;
using UnityEngine.UI;

namespace Anita
{
    public class TitleController : ViewControllerBase
    {
        public Button exitButton;
        public AudioController bgmController;
        public string bgmName;
        public float bgmVolume = 0.5f;

        private const string SelectChapterFirstShownKey = ConfigViewController.FirstShownKeyPrefix + "SelectChapter";

        private GameState gameState;
        private ConfigManager configManager;
        private CheckpointManager checkpointManager;

        protected override void Awake()
        {
            base.Awake();

            var controller = Utils.FindAnitaGameController();
            gameState = controller.GameState;
            configManager = controller.ConfigManager;
            checkpointManager = controller.CheckpointManager;

            exitButton.onClick.AddListener(() =>
                Hide(Utils.Quit)
            );
        }

        protected override void Start()
        {
            base.Start();
            gameState.SaveInitialState();
            Show(null);
        }

        public override void Show(Action onFinish)
        {
            base.Show(() =>
            {
                viewManager.dialoguePanel.SetActive(false);
                viewManager.StopAllAnimations();
                gameState.ResetGameState();

                if (bgmController != null && !string.IsNullOrEmpty(bgmName))
                {
                    bgmController.scriptVolume = bgmVolume;
                    bgmController.Play(bgmName);
                }

                if (configManager.GetInt(SelectChapterFirstShownKey) == 0)
                {
                    var unlockedChapterCount = gameState.GetAllUnlockedStartNodeNames().Count;
                    var reachedChapterCount = gameState.GetAllStartNodeNames()
                        .Count(name => checkpointManager.GetReachedForAnyVariables(name, 0) != null);
                    if (unlockedChapterCount == 1 && reachedChapterCount > 1)
                    {
                        Alert.Show(I18n.__("title.first.selectchapter"));
                        configManager.SetInt(SelectChapterFirstShownKey, 1);
                    }
                }

                onFinish?.Invoke();
            });
        }

        protected override void Update() { }
    }
}