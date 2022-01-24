﻿using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityObject = UnityEngine.Object;

namespace Anita
{
    [ExportCustomType]
    public enum AssetCacheType
    {
        Image,
        StandingLayer,
        Timeline,
        Audio
    }

    // Load assets at runtime and manage preloaded assets
    // All assets should be stored in a Resources folder, or a subfolder in it
    [ExportCustomType]
    public class AssetLoader : MonoBehaviour, IPrioritizedRestorable
    {
        private static AssetLoader Current;

        private static readonly HashSet<string> LocalizedResourcePaths = new HashSet<string>();

        // The reference of the asset is stored in request
        private class CachedAssetEntry
        {
            public int count;
            public ResourceRequest request;
        }

        private Dictionary<AssetCacheType, LRUCache<string, CachedAssetEntry>> cachedAssets;
        private GameState gameState;

        private void Awake()
        {
            Current = this;

            var text = Resources.Load<TextAsset>("LocalizedResourcePaths").text;
            LocalizedResourcePaths.UnionWith(text.Split('\n'));

            cachedAssets = new Dictionary<AssetCacheType, LRUCache<string, CachedAssetEntry>>
            {
                [AssetCacheType.Image] = new LRUCache<string, CachedAssetEntry>(autoDestroy: true, maxSize: 20),
                [AssetCacheType.StandingLayer] = new LRUCache<string, CachedAssetEntry>(autoDestroy: true, maxSize: 20),
                [AssetCacheType.Timeline] = new LRUCache<string, CachedAssetEntry>(autoDestroy: true, maxSize: 1),
                [AssetCacheType.Audio] = new LRUCache<string, CachedAssetEntry>(autoDestroy: true, maxSize: 4)
            };

            gameState = Utils.FindAnitaGameController().GameState;
            gameState.AddRestorable(this);

            Application.lowMemory += UnloadUnusedAndCachedAssets;
            I18n.LocaleChanged.AddListener(OnLocaleChanged);
        }

        private void OnDestroy()
        {
            Current = null;
            gameState.RemoveRestorable(this);
            Application.lowMemory -= UnloadUnusedAndCachedAssets;
            I18n.LocaleChanged.RemoveListener(OnLocaleChanged);
        }

        #region Methods independent of current and cache

        private static string TryGetLocalizedPath(string path)
        {
            if (I18n.CurrentLocale == I18n.DefaultLocale)
            {
                return path;
            }

            var localizedPath = I18n.LocalePath + I18n.CurrentLocale + "/" + path;

            if (!LocalizedResourcePaths.Contains(localizedPath))
            {
                return path;
            }

            return localizedPath;
        }

        public static T LoadOrNull<T>(string path) where T : UnityObject
        {
            path = Utils.ConvertPathSeparator(path);
            path = TryGetLocalizedPath(path);
            return Resources.Load<T>(path);
        }

        // Load with null check
        public static T Load<T>(string path) where T : UnityObject
        {
            T ret = LoadOrNull<T>(path);
            if (ret == null)
            {
                Debug.LogErrorFormat("Anita: {0} {1} not found.", typeof(T).Name, path);
            }

            return ret;
        }

        // Specified type used for Lua binding
        public static Texture LoadTexture(string path)
        {
            return Load<Texture>(path);
        }

        public static void UnloadUnusedAssets()
        {
            Resources.UnloadUnusedAssets();
        }

        #endregion

        #region Methods using cache

        public static void UnloadUnusedAndCachedAssets()
        {
            foreach (var cache in Current.cachedAssets.Values)
            {
                cache.Clear();
            }

            Resources.UnloadUnusedAssets();
        }

        public static void Preload(AssetCacheType type, string path)
        {
            path = Utils.ConvertPathSeparator(path);

            // Debug.LogFormat("Preload {0}:{1}", type, path);
            var cache = Current.cachedAssets[type];
            if (cache.ContainsKey(path))
            {
                cache[path].count++;
            }
            else
            {
                // Debug.LogFormat("Add cache {0}:{1}", type, path);
                var localizedPath = TryGetLocalizedPath(path);
                cache[path] = new CachedAssetEntry {count = 1, request = Resources.LoadAsync(localizedPath)};
            }
        }

        public static void Unpreload(AssetCacheType type, string path)
        {
            path = Utils.ConvertPathSeparator(path);

            // Debug.LogFormat("Unpreload {0}:{1}", type, path);
            var cache = Current.cachedAssets[type];
            if (cache.ContainsKey(path))
            {
                var entry = cache.GetNoTouch(path);
                entry.count--;
                if (entry.count <= 0)
                {
                    // Debug.LogFormat("Remove cache {0}:{1}", type, path);
                    cache.Remove(path);
                }
            }
            else
            {
                Debug.LogWarningFormat("Anita: Asset {0}:{1} not cached when unpreloading.", type, path);
            }
        }

        // Refresh cache on locale changed
        private void OnLocaleChanged()
        {
            var cache = cachedAssets[AssetCacheType.Image];
            foreach (var path in cache.Keys)
            {
                var localizedPath = I18n.LocalePath + I18n.CurrentLocale + "/" + path;
                if (LocalizedResourcePaths.Contains(localizedPath))
                {
                    cache[path].request = Resources.LoadAsync(localizedPath);
                }
            }
        }

        #endregion

        #region Restoration

        public RestorablePriority priority => RestorablePriority.Preload;
        public string restorableObjectName => "AssetLoader";

        [Serializable]
        private class AssetLoaderRestoreData : IRestoreData
        {
            public readonly Dictionary<AssetCacheType, Dictionary<string, int>> cachedAssetCounts;

            public AssetLoaderRestoreData(Dictionary<AssetCacheType, LRUCache<string, CachedAssetEntry>> cachedAssets)
            {
                cachedAssetCounts = cachedAssets.ToDictionary(
                    pair => pair.Key,
                    pair => pair.Value.ToDictionary(
                        innerPair => innerPair.Key,
                        innerPair => innerPair.Value.count
                    )
                );
            }
        }

        public IRestoreData GetRestoreData()
        {
            return new AssetLoaderRestoreData(cachedAssets);
        }

        public void Restore(IRestoreData restoreData)
        {
            var data = restoreData as AssetLoaderRestoreData;
            // Serialized assets are in MRU order
            foreach (var pair in data.cachedAssetCounts)
            {
                var type = pair.Key;
                var cache = cachedAssets[type];
                cache.Clear();
                foreach (var pathAndCount in pair.Value)
                {
                    var path = pathAndCount.Key;
                    var count = pathAndCount.Value;
                    var localizedPath = TryGetLocalizedPath(path);
                    var request = Resources.LoadAsync(localizedPath);
                    cache[path] = new CachedAssetEntry {count = count, request = request};
                }
            }
        }

        #endregion

        public static void DebugPrint()
        {
            foreach (var pair in Current.cachedAssets)
            {
                var type = pair.Key;
                var cache = pair.Value;
                Debug.LogFormat("{0} {1} {2}", type, cache.Count, cache.HistoryMaxCount);
            }
        }
    }
}