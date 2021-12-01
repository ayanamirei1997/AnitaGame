﻿/*
 * 编辑器相关脚本，主要进行人物立绘图片的预处理
 * 1、把要用的png相关图片组合成一个prefab，并添加裁剪脚本  -->  CreateUncroppedStandingWithSelectedSprites()
 * 2、自动裁剪  --> AutoCrop()
 * 3、保存裁剪后的sprite  --> WriteCropResult()
 * 4、生成metadata保存自定义偏移数据  -->  GenerateMetaData()
 */
using System.IO;
using UnityEditor;
using UnityEngine;

namespace Anita
{
    [CustomEditor(typeof(UncroppedStanding))]
    public class UncroppedStandingEditor : UnityEditor.Editor
    {
        private static void ResetTransform(Transform transform)
        {
            transform.position = Vector3.zero;
            transform.localScale = Vector3.one;
            transform.rotation = Quaternion.identity;
        }

        [MenuItem("Assets/Create/Anita/根据PNG自动生成prefab", false)]
        public static void CreateUncroppedStandingWithSelectedSprites()
        {
            // 先创建一个父物体
            const string assetName = "UncroppedStanding";
            var parent = new GameObject(assetName);
            ResetTransform(parent.transform);
            parent.AddComponent<UncroppedStanding>();

            // 把所有选择的图片作为子物体，分别添加裁剪脚本
            foreach (var spritePath in EditorUtils.GetSelectedSpritePaths())
            {
                var go = new GameObject("StandingComponent");
                go.transform.SetParent(parent.transform);
                ResetTransform(go.transform);
                var sprite = AssetDatabase.LoadAssetAtPath<Sprite>(spritePath);
                var spriteRenderer = go.AddComponent<SpriteRenderer>();
                spriteRenderer.sprite = sprite;
                var texture = sprite.texture;
                var cropper = go.AddComponent<SpriteCropper>();
                cropper.boundRect = new RectInt(0, 0, texture.width, texture.height);
                cropper.cropRect = new RectInt(0, 0, texture.width, texture.height);
            }

            var currentDir = EditorUtils.GetSelectedDirectory();

            // 把处理好后的prefab保存起来
            PrefabUtility.SaveAsPrefabAsset(parent,
                Path.Combine(currentDir, AssetDatabase.GenerateUniqueAssetPath(assetName + ".prefab")));
            DestroyImmediate(parent);
        }

        [MenuItem("Assets/Create/Anita/根据PNG自动生成prefab", true)]
        public static bool CreateUncroppedStandingWithSelectedSpritesValidation()
        {
            var path = AssetDatabase.GetAssetPath(Selection.activeObject);
            return AssetDatabase.GetMainAssetTypeAtPath(path) == typeof(Texture2D);
        }

        private bool useCaptureBox;
        private RectInt captureBox = new RectInt(0, 0, 400, 400);

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            var standing = target as UncroppedStanding;

            // 自定义 capture box进行裁剪
            useCaptureBox = GUILayout.Toggle(useCaptureBox, "Use Capture Box");
            if (useCaptureBox)
            {
                GUILayout.BeginHorizontal();
                GUILayout.Label("Capture Box");
                captureBox = EditorGUILayout.RectIntField(captureBox);
                GUILayout.EndHorizontal();
            }

            // 自动裁剪
            // 原理：读取texture的colors, 取得有像素部分的最小包围
            if (GUILayout.Button("Auto Crop All"))
            {
                foreach (var cropper in standing.GetComponentsInChildren<SpriteCropper>())
                {
                    var texture = cropper.sprite.texture;
                    if (useCaptureBox)
                    {
                        cropper.boundRect.xMin = captureBox.xMin;
                        cropper.boundRect.yMin = texture.height - captureBox.yMax;
                        cropper.boundRect.size = captureBox.size;
                    }
                    else
                    {
                        cropper.boundRect.min = Vector2Int.zero;
                        cropper.boundRect.width = texture.width;
                        cropper.boundRect.height = texture.height;
                    }

                    SpriteCropperEditor.AutoCrop(cropper);
                }
            }

            // 保存裁剪后的sprite
            if (GUILayout.Button("Write Cropped Textures"))
            {
                WriteCropResult(standing);
            }

            // 生成metadata保存自定义偏移数据
            if (GUILayout.Button("Generate Metadata"))
            {
                GenerateMetaData(standing);
            }
        }

        private static void WriteCropResult(UncroppedStanding standing)
        {
            foreach (var cropper in standing.GetComponentsInChildren<SpriteCropper>())
            {
                WriteCropResult(standing, cropper);
            }

            AssetDatabase.Refresh();
        }

        // 保存裁剪后的文件
        private static void WriteCropResult(UncroppedStanding standing, SpriteCropper cropper)
        {
            var cropRect = cropper.cropRect;
            var cropped = new Texture2D(cropRect.width, cropRect.height, TextureFormat.RGBA32, false);

            var texture = cropper.sprite.texture;
            var pixels = texture.GetPixels(cropRect.x, cropRect.y, cropRect.width, cropRect.height);
            cropped.SetPixels(pixels);
            cropped.Apply();

            var bytes = cropped.EncodeToPNG();
            var absoluteOutputFileName = Path.Combine(standing.absoluteOutputDirectory, cropper.sprite.name + ".png");
            Directory.CreateDirectory(Path.GetDirectoryName(absoluteOutputFileName));
            File.WriteAllBytes(absoluteOutputFileName, bytes);
        }

        private static void GenerateMetaData(UncroppedStanding standing)
        {
            foreach (var cropper in standing.GetComponentsInChildren<SpriteCropper>())
            {
                GenerateMetaData(standing, cropper);
            }
        }

        // 生成并使用asset文件保存偏移
        private static void GenerateMetaData(UncroppedStanding standing, SpriteCropper cropper)
        {
            var meta = CreateInstance<OffsetSprite>();
            meta.offset = (cropper.cropRect.center - cropper.boundRect.center) / cropper.sprite.pixelsPerUnit;
            var path = Path.Combine(standing.outputDirectory, cropper.sprite.name + ".png");
            meta.sprite = AssetDatabase.LoadAssetAtPath<Sprite>(path);
            AssetDatabase.CreateAsset(meta, Path.Combine(standing.outputDirectory, cropper.sprite.name + ".asset"));
        }
    }
}