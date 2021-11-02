using Anita;
using System;
using System.Collections.Generic;
using LuaInterface;
using UnityEngine;

namespace Anita
{
    // 本地化
    public class LocalizedDialogueEntry
    {
        public string displayName;
        public string dialogue;
    }

    // 序列化
    [Serializable]
    public class DialogueDisplayData
    {
        // 角色名字
        public readonly string characterName;
        // 显示的名字
        public readonly Dictionary<SystemLanguage, string> displayNames;
        // 对话
        public readonly Dictionary<SystemLanguage, string> dialogues;

        public DialogueDisplayData(string characterName, Dictionary<SystemLanguage, string> displayNames, 
        Dictionary<SystemLanguage, string> dialogues)
        {
            this.characterName = characterName;
            this.displayNames = displayNames;
            this.dialogues = dialogues;
        }

        // 本地化中的格式化
        public string FormatNameDialogue()
        {
            // var name = I18n.__(displayNames);
            // var dialogue = I18n.__(dialogues);
            // if (string.IsNullOrEmpty(name))
            // {
            //     return dialogue;
            // }
            // else
            // {
            //     return string.Format(I18n.__("format.namedialogue"), name, dialogue);
            // }
            return "";
        }
    }

    // 每个entry包括名字和对话 以及要执行的action
    public class DialogueEntry
    {
        // 内部角色名
        public readonly string characterName;

        // 国际化后的
        public readonly Dictionary<SystemLanguage, string> displayNames = new Dictionary<SystemLanguage, string>();

        // 对
        public readonly Dictionary<SystemLanguage, string> dialogues = new Dictionary<SystemLanguage, string>();

        // 要执行的action
        private readonly LuaFunction action;

        public DialogueEntry(string characterName, string displayName, string dialogue, LuaFunction action)
        {
            this.characterName = characterName;
            // displayNames[I18n.DefaultLocale] = displayName;
            // dialogues[I18n.DefaultLocale] = dialogue;
            this.action = action;
        }

        public void AddLocale(SystemLanguage locale, LocalizedDialogueEntry entry)
        {
            displayNames[locale] = entry.displayName;
            dialogues[locale] = entry.dialogue;
        }

        // 执行entry中的action
        public void ExecuteAction()
        {
            if (action != null)
            {
                // try
                // {
                //     action.Call();
                // }
                // catch (LuaException ex)
                // {
                //     throw new ScriptActionException(
                //         $"Nova: Exception occurred when executing action: {I18n.__(dialogues)}", ex);
                // }
            }
        }

        public DialogueDisplayData displayData => new DialogueDisplayData(characterName, displayNames, dialogues);
    }



}