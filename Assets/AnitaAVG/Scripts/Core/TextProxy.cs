/*
 * 处理一些文本的刷新与换行等。
 */

using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Anita
{
    [RequireComponent(typeof(TMP_Text))]
    public class TextProxy : MonoBehaviour
    {
        private static readonly HashSet<char> ChineseFollowingPunctuations = new HashSet<char>("，。、；：？！…—‘’“”（）【】《》");

        private static bool IsChineseCharacter(char c)
        {
            return c >= 0x4e00 && c <= 0x9fff;
        }

        public TMP_Text textBox { get; private set; }

        private bool inited;
        // 下一句开始刷新
        private bool needRefreshLineBreak;
        // 淡入淡出刷新
        private bool needRefreshFade;
        // 下一帧就刷新
        private bool needRefreshAtNextFrame;

        private void Awake()
        {
            Init();
        }

        public void Init()
        {
            if (inited) return;
            textBox = GetComponent<TMP_Text>();
            inited = true;
        }
        
        // 当调用ScheduleRefresh（）刷新时，transform在LateUpdate刷新
        public void ScheduleRefresh()
        {
            needRefreshAtNextFrame = true;
        }

        private string _text;

        public string text
        {
            get => _text;
            set
            {
                if (_text == value) return;
                _text = value;
                textBox.text = value;
                needRefreshLineBreak = true;
            }
        }

        private string _materialName;

        public string materialName
        {
            get => _materialName;
            set
            {
                if (_materialName == value) return;
                _materialName = value;
                UpdateFont();
            }
        }

        public void UpdateFont()
        {
            foreach (var pair in I18nFontConfig.Config)
            {
                if (pair.locale == I18n.CurrentLocale)
                {
                    textBox.font = pair.fontAsset;
                    textBox.fontSharedMaterial = pair.fontAsset.material;

                    foreach (var nameAndMaterial in pair.materials)
                    {
                        if (nameAndMaterial.name == materialName)
                        {
                            textBox.fontSharedMaterial = nameAndMaterial.material;
                            break;
                        }
                    }

                    break;
                }
            }

            needRefreshLineBreak = true;
        }

        public float fontSize
        {
            get => textBox.fontSize;
            set
            {
                if (Mathf.Approximately(textBox.fontSize, value)) return;
                textBox.fontSize = value;
                needRefreshLineBreak = true;
            }
        }

        private byte targetAlpha = 255;
        private float fadeValue = 1.0f;

        public void SetFade(byte targetAlpha, float fadeValue)
        {
            this.targetAlpha = targetAlpha;
            this.fadeValue = fadeValue;
            needRefreshFade = true;
        }

        private void OnEnable()
        {
            needRefreshLineBreak = true;
            needRefreshFade = true;
        }

        private void LateUpdate()
        {
            if (needRefreshLineBreak || needRefreshFade)
            {
                Refresh();
            }

            if (needRefreshAtNextFrame)
            {
                needRefreshAtNextFrame = false;
                needRefreshLineBreak = true;
                needRefreshFade = true;
            }
        }

        // 如果最后一行是一个汉字和一些（或零个）中文标点符号，
        // 倒数第二行的最后一个字符是汉字，
        // 则在倒数第二行的最后一个字符之前添加换行符
        // 现在我们使用 Tools/Scenarios/add_soft_hyphens.py 来预先计算连字符
        private void ApplyLineBreak(string text)
        {
            var textInfo = textBox.GetTextInfo(text);

            if (textInfo.lineCount >= 2)
            {
                var lineInfo = textInfo.lineInfo[textInfo.lineCount - 1];
                int firstIdx = lineInfo.firstCharacterIndex;

                bool needBreak = firstIdx >= 1 && IsChineseCharacter(text[firstIdx]);

                // 需要换行
                if (needBreak)
                {
                    int lastIdx = lineInfo.lastCharacterIndex;
                    for (int i = firstIdx + 1; i <= lastIdx; ++i)
                    {
                        if (!ChineseFollowingPunctuations.Contains(text[i]))
                        {
                            needBreak = false;
                            break;
                        }
                    }
                }

                if (needBreak)
                {
                    if (!IsChineseCharacter(text[firstIdx - 1]))
                    {
                        needBreak = false;
                    }
                }

                if (needBreak)
                {
                    text = text.Insert(firstIdx - 1, "\n");
                }
            }

            textBox.text = text;
        }

        public void SetTextAlpha(byte a)
        {
            textBox.color = Utils.SetAlpha32(textBox.color, a);
        }

        private void ApplyAlphaToCharAtIndex(int index, byte alpha)
        {
            var characterInfo = textBox.textInfo.characterInfo;
            if (!characterInfo[index].isVisible) return;

            // 不同Characters可能有不同的materials
            var meshInfo = textBox.textInfo.meshInfo;
            var materialIndex = characterInfo[index].materialReferenceIndex;
            var newVertexColors = meshInfo[materialIndex].colors32;
            var vertexIndex = characterInfo[index].vertexIndex;
            newVertexColors[vertexIndex + 0].a = alpha;
            newVertexColors[vertexIndex + 1].a = alpha;
            newVertexColors[vertexIndex + 2].a = alpha;
            newVertexColors[vertexIndex + 3].a = alpha;
        }

        private void ApplyFade()
        {
            // due to some strange behaviour of TMP, manually check special case
            if (fadeValue >= 1.0f - 1e-3f)
            {
                SetTextAlpha(targetAlpha);
                return;
            }

            SetTextAlpha(0);

            var characterCount = textBox.textInfo.characterCount;
            var fadingCharacterIndex = Mathf.FloorToInt(characterCount * fadeValue);
            // handle fully visible characters
            for (var i = 0; i < fadingCharacterIndex; ++i)
            {
                ApplyAlphaToCharAtIndex(i, targetAlpha);
            }

            // handle fading character
            var tint = Mathf.Clamp01(characterCount * fadeValue - fadingCharacterIndex);
            var alpha = (byte)(targetAlpha * tint);
            ApplyAlphaToCharAtIndex(fadingCharacterIndex, alpha);

            // handle hidden characters
            for (var i = fadingCharacterIndex + 1; i < characterCount; i++)
            {
                ApplyAlphaToCharAtIndex(i, 0);
            }
        }

        private void Refresh()
        {
            if (!gameObject.activeInHierarchy)
            {
                textBox.text = text;
                return;
            }

            if (needRefreshLineBreak)
            {
                needRefreshLineBreak = false;
                if (string.IsNullOrEmpty(text))
                {
                    textBox.text = text;
                }
                else
                {
                    ApplyLineBreak(text);
                }
            }

            if (needRefreshFade)
            {
                needRefreshFade = false;
                ApplyFade();
            }

            if (needRefreshLineBreak)
            {
                textBox.ForceMeshUpdate();
            }
            else
            {
                textBox.UpdateVertexData(TMP_VertexDataUpdateFlags.Colors32);
            }
        }
    }
}