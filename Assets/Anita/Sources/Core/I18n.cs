/*
 * 本地化/多语言处理
 */

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;

namespace Anita
{
    // Example:
    // "ivebeenthere": ["I've never been there", "I've been there once", "I've been there twice", "I've been there {0} times"]
    // __("ivebeenthere", 2) == "I've been there twice"
    // __("ivebeenthere", 4) == "I've been there 4 times"
    using TranslationBundle = Dictionary<string, object>;

    [ExportCustomType]
    public static class I18n
    {
        public const string LocalePath = "Locales/";

        public static readonly SystemLanguage[] SupportedLocales =
            {SystemLanguage.ChineseSimplified, SystemLanguage.English};

        public static SystemLanguage DefaultLocale => SupportedLocales[0];

        private static SystemLanguage _currentLocale = FallbackLocale(Application.systemLanguage);

        public static SystemLanguage CurrentLocale
        {
            get => _currentLocale;
            set
            {
                value = FallbackLocale(value);
                if (value == _currentLocale)
                {
                    return;
                }

                _currentLocale = value;
                LocaleChanged.Invoke();
            }
        }

        private static SystemLanguage FallbackLocale(SystemLanguage locale)
        {
            if (locale == SystemLanguage.Chinese || locale == SystemLanguage.ChineseSimplified ||
                locale == SystemLanguage.ChineseTraditional)
            {
                return SystemLanguage.ChineseSimplified;
            }
            else
            {
                return SystemLanguage.English;
            }
        }

        public static readonly UnityEvent LocaleChanged = new UnityEvent();

        private static bool Inited;

        private static void Init()
        {
            if (Inited) return;
            LoadTranslationBundles();
            Inited = true;
        }

        private static readonly Dictionary<SystemLanguage, TranslationBundle> TranslationBundles =
            new Dictionary<SystemLanguage, TranslationBundle>();

        private static void LoadTranslationBundles()
        {
            foreach (var locale in SupportedLocales)
            {
                var textAsset = Resources.Load(LocalePath + locale) as TextAsset;
                TranslationBundles[locale] = JsonConvert.DeserializeObject<TranslationBundle>(textAsset.text);
            }
        }
        
        public static string __(SystemLanguage locale, string key, params object[] args)
        {
#if UNITY_EDITOR
            EditorOnly_GetLatestTranslation();
#endif

            Init();

            string translation = key;

            if (TranslationBundles[locale].TryGetValue(key, out var raw))
            {
                if (raw is string value)
                {
                    translation = value;
                }
                else if (raw is string[] formats)
                {
                    if (formats.Length == 0)
                    {
                        Debug.LogWarningFormat("Anita: Empty translation string list for: {0}", key);
                    }
                    else if (args.Length == 0)
                    {
                        translation = formats[0];
                    }
                    else
                    {
                        // 第一个参数将确定数量
                        object arg1 = args[0];
                        if (arg1 is int i)
                        {
                            translation = formats[Math.Min(i, formats.Length - 1)];
                        }
                    }
                }
                else
                {
                    Debug.LogWarningFormat("Anita: Invalid translation format for: {0}", key);
                }

                if (args.Length > 0)
                {
                    translation = string.Format(translation, args);
                }
            }
            else
            {
                Debug.LogWarningFormat("Anita: Missing translation for: {0}", key);
            }

            return translation;
        }

        public static string __(string key, params object[] args)
        {
            return __(CurrentLocale, key, args);
        }

        // 返回对应语言
        public static string __(Dictionary<SystemLanguage, string> dict)
        {
            if (dict.ContainsKey(CurrentLocale))
            {
                return dict[CurrentLocale];
            }
            else
            {
                return dict[DefaultLocale];
            }
        }

#if UNITY_EDITOR
        private static string EditorTranslationPath => "Assets/Anita/Resources/" + LocalePath + CurrentLocale + ".json";

        private static DateTime LastWriteTime;

        private static void EditorOnly_GetLatestTranslation()
        {
            var writeTime = File.GetLastWriteTime(EditorTranslationPath);
            if (writeTime != LastWriteTime)
            {
                LastWriteTime = writeTime;
                Inited = false;
            }
        }
#endif
    }
}