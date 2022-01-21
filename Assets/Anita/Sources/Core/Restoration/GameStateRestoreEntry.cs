using System;
using System.Collections.Generic;
using UnityEngine.Assertions;

namespace Anita
{
    // 对于所有支持了 restorable 的 gameobject , 存储所有的 restoration information

    // 由于 Anita 脚本语法的设计，每个步骤中对象的状态只能在运行时知道。
    // 要实现后退功能，游戏状态对象应该知道每一步的所有 GameStateRestoreEntry 以执行后退。
    // 为了使从检查点加载后的后退步骤功能仍然有效，CheckpointManager 应该存储所有 GameStateRestoreEntry 用于已通过的 dialogues。
    [Serializable]
    public abstract class GameStateRestoreEntry
    {
        // 该值保证为非负值
        // if StepNumFromLastCheckpoint == 0, restoreDatas is valid
        // otherwise restoreDatas == null
        public readonly int stepNumFromLastCheckpoint;

        public readonly int restrainCheckpointNum;

        protected GameStateRestoreEntry(int stepNumFromLastCheckpoint, int restrainCheckpointNum)
        {
            this.stepNumFromLastCheckpoint = stepNumFromLastCheckpoint;
            this.restrainCheckpointNum = restrainCheckpointNum;
        }
    }

    [Serializable]
    public class GameStateCheckpoint : GameStateRestoreEntry
    {
        private readonly Dictionary<string, IRestoreData> restoreDatas;

        public readonly Variables variables;

        public GameStateCheckpoint(Dictionary<string, IRestoreData> restoreDatas, Variables variables,
            int restrainCheckpointNum)
            : base(0, restrainCheckpointNum)
        {
            this.restoreDatas = restoreDatas;
            this.variables = new Variables();
            this.variables.CopyFrom(variables);
        }

        public IRestoreData this[string restorableObjectName] => restoreDatas[restorableObjectName];
    }

    [Serializable]
    public class GameStateSimpleEntry : GameStateRestoreEntry
    {
        public readonly ulong lastCheckpointVariablesHash;

        public GameStateSimpleEntry(int stepNumFromLastCheckpoint, int restrainCheckpointNum,
            ulong lastCheckpointVariablesHash)
            : base(stepNumFromLastCheckpoint, restrainCheckpointNum)
        {
            Assert.IsTrue(stepNumFromLastCheckpoint > 0,
                $"Anita: Invalid stepNumFromLastCheckpoint for GameStateSimpleEntry: {stepNumFromLastCheckpoint}");
            this.lastCheckpointVariablesHash = lastCheckpointVariablesHash;
        }
    }
}