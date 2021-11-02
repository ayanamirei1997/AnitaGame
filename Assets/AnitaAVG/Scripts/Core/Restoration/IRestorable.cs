// 本接口代表 当游戏状态改变时，当前prefab可以存储相关信息

namespace Anita
{
    
    public interface IRestorable
    {
        // 每个prefab应该
        string restorableObjectName { get; }
        
        // 应该在每条对话发生时调用
        IRestoreData GetRestoreData();

        // 应该在游戏读档时调用
        void Restore(IRestoreData data);
    }

}