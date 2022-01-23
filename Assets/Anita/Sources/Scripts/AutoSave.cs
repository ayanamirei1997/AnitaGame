﻿using UnityEngine;

namespace Anita
{
    public class AutoSave : MonoBehaviour
    {
        public float maxTime = 10.0f;

        private bool isPaused;
        private float time;

        private void Update()
        {
            if (isPaused || time >= maxTime)
            {
                return;
            }

            time += Time.deltaTime;
        }

        public void OnApplicationFocus(bool hasFocus)
        {
            isPaused = !hasFocus;
            TrySave();
        }

        public void OnApplicationPause(bool pauseStatus)
        {
            isPaused = pauseStatus;
            TrySave();
        }

        private void TrySave()
        {
            if (!isPaused || time < maxTime)
            {
                return;
            }

            Utils.SaveAll();
            time = 0.0f;
        }
    }
}