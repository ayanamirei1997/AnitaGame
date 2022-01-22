/*
 * 对白序列 dialogue entry
 */

using Anita.Exceptions;
using System;
using System.Collections.Generic;
using LuaInterface;
using UnityEngine;

namespace Anita
{
    public class LocalizedDialogueEntry
    {
        public string displayName;
        public string dialogue;
    }
    
    [Serializable]
    public class DialogueDisplayData
    {
        public readonly string characterName;
        public readonly Dictionary<SystemLanguage, string> displayNames;
        public readonly Dictionary<SystemLanguage, string> dialogues;

        public DialogueDisplayData(string characterName, Dictionary<SystemLanguage, string> displayNames,
            Dictionary<SystemLanguage, string> dialogues)
        {
            this.characterName = characterName;
            this.displayNames = displayNames;
            this.dialogues = dialogues;
        }

        public string FormatNameDialogue()
        {
            var name = I18n.__(displayNames);
            var dialogue = I18n.__(dialogues);
            if (string.IsNullOrEmpty(name))
            {
                return dialogue;
            }
            else
            {
                return string.Format(I18n.__("format.namedialogue"), name, dialogue);
            }
        }
    }

    // 每个dialogue entry 包含 characterName 和对应的dialogues 以及要执行的action
    public class DialogueEntry
    {
        // 内部使用的 character name
        public readonly string characterName;

        /// 本地化对应的 name
        public readonly Dictionary<SystemLanguage, string> displayNames = new Dictionary<SystemLanguage, string>();

        /// 本地化对应的 dialogues
        public readonly Dictionary<SystemLanguage, string> dialogues = new Dictionary<SystemLanguage, string>();

        // 游戏程序到达该 point 时要执行的 action
        private readonly LuaFunction action;

        public DialogueEntry(string characterName, string displayName, string dialogue, LuaFunction action)
        {
            this.characterName = characterName;
            displayNames[I18n.DefaultLocale] = displayName;
            dialogues[I18n.DefaultLocale] = dialogue;
            this.action = action;
        }

        public void AddLocale(SystemLanguage locale, LocalizedDialogueEntry entry)
        {
            displayNames[locale] = entry.displayName;
            dialogues[locale] = entry.dialogue;
        }

        // 执行 entry 中的action
        public void ExecuteAction()
        {
            if (action != null)
            {
                try
                {
                    action.Call();
                }
                catch (LuaException ex)
                {
                    throw new ScriptActionException(
                        $"Anita: Exception occurred when executing action: {I18n.__(dialogues)}", ex);
                }
            }
        }

        public DialogueDisplayData displayData => new DialogueDisplayData(characterName, displayNames, dialogues);
    }
}