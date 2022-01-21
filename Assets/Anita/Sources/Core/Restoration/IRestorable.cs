namespace Anita
{
    // 这个接口表示一个对象，当 GameState 回退时可以恢复其状态
    
    public interface IRestorable
    {
        // 所有的 IRestorable 都应该有一个唯一的非 null 名字，这个名字在运行时不应该改变，
        string restorableObjectName { get; }
        
        // 获取恢复游戏对象状态所必需的数据
        // 每次DialogueChanged事件发生后都会调用该方法
        // 恢复游戏对象状态所必需的数据
        IRestoreData GetRestoreData();


        // Restore the restorable object using the restore data
        // 当游戏流程倒退时将调用此方法
        void Restore(IRestoreData restoreData);
    }
}