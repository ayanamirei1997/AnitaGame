/*
 * 警告框
 */

using System;
using UnityEngine;
using UnityEngine.Events;

namespace Anita
{
    [Serializable]
    public class AlertParameters
    {
        // 标题
        public string title;
        // 正文
        public string bodyContent;
        public Action onConfirm;
        public Action onCancel;
        public string ignoreKey;
        // lite为true时，只是一个简单通知，会自动淡出
        public bool lite;
    }

    [Serializable]
    public class AlertEvent : UnityEvent<AlertParameters> { }

    // 使用警告时的委托    
    [ExportCustomType]
    public class Alert : MonoBehaviour
    {
        public const string AlertKeyPrefix = ConfigManager.TrackedKeyPrefix + "Alert";

        public AlertEvent alertFunction;

        private static AlertEvent _alert;

        private void Awake()
        {
            if (alertFunction == null)
            {
                Debug.LogError("Anita: AlertFunction not set on Alert component.");
                Utils.Quit();
            }

            _alert = alertFunction;
        }
        
        // 显示游戏提供的警报框。将这两个 action 留空以隐藏取消按钮。
        // ignoreKey: 用户确认忽视警告   "" 禁用此功能
        /// <param name="ignoreKey">A key to identify the alert box when prompting user to ignore it. "" to disable this feature.</param>
        public static void Show(string title, string bodyContent,
            Action onClickConfirm = null, Action onClickCancel = null,
            string ignoreKey = "")
        {
            AssertAlertFunction();
            _alert.Invoke(new AlertParameters
            {
                title = title,
                bodyContent = bodyContent,
                onConfirm = onClickConfirm,
                onCancel = onClickCancel,
                ignoreKey = ignoreKey == "" ? "" : AlertKeyPrefix + ignoreKey,
                lite = false
            });
        }

        // 显示一个简单的通知，它会自行淡出。
        public static void Show(string content, Action onFinish = null)
        {
            AssertAlertFunction();
            _alert.Invoke(new AlertParameters
            {
                bodyContent = content,
                onCancel = onFinish,
                lite = true
            });
        }
        
        private static void AssertAlertFunction()
        {
            if (_alert == null)
            {
                if (StackTraceUtility.ExtractStackTrace().Contains("Awake"))
                    Debug.LogError("Anita: Alert() should not be called in Awake().");
                else
                    Debug.LogError("Anita: Missing Alert component in initial scene.");
                Utils.Quit();
            }
        }
    }
}