// 国际化接口
// TODO 以后支持国际化 目前只用来提供部分接口
using Newtonsoft.Json; // 调用NewtonsoftJson.dll
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;

namespace Anita
{
    // object的json化
    //
    // Example:
    // "ivebeenthere": ["I've never been there", "I've been there once", "I've been there twice", "I've been there {0} times"]
    // __("ivebeenthere", 2) == "I've been there twice"
    // __("ivebeenthere", 4) == "I've been there 4 times"
    using TranslationBundle = Dictionary<string, object>;

    //[ExportCustomType]
    public static class I18n
    {
        public const string LocalePath = "Locales/";

        // 至少先支持下中英
        public static readonly SystemLanguage[] SupportedLocales =
            {SystemLanguage.ChineseSimplified, SystemLanguage.English};
        
        // 默认肯定是中文
        public static SystemLanguage DefaultLocale => SupportedLocales[0];

        // Note: 这里也不应该特别绝对 目前先根据机体语言环境选择
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

        // 本地化的回调 目前只支持中英
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

        // 初始化
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
                // 把asset反序列化回去
                TranslationBundles[locale] = JsonConvert.DeserializeObject<TranslationBundle>(textAsset.text);
            }
        }

        /// <summary>
        /// 通过key和参数返回本地化翻译
        /// </summary>
        /// <param name="locale"></param>
        /// <param name="key">Key to specify the translation</param>
        /// <param name="args">Arguments to provide to the translation as a format string.<para />
        /// <returns>The translated string.</returns>
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
                        // 第一参数表示数量
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

        // 带默认的本地化翻译
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
        private static string EditorTranslationPath => "Assets/AnitaAVG/Resources/" + LocalePath + CurrentLocale + ".json";

        private static DateTime LastWriteTime;

        private static void EditorOnly_GetLatestTranslation()
        {
            var writeTime = File.GetLastWriteTime(EditorTranslationPath);
            if (writeTime != LastWriteTime)
            {
                LastWriteTime = writeTime;
                // 编辑时修改了文本翻译 则重置一下
                Inited = false;
            }
        }
#endif
    }
}