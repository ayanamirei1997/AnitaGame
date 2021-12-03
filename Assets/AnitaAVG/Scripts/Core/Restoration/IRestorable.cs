// 如名字所示，本接口代表当游戏状态改变时，当前object可以存储相关信息
namespace Anita
{
    public interface IRestorable
    {
        // 至少应该有一个唯一的name标志自己
        string restorableObjectName { get; }
        
        // 恢复游戏对象状态必不可少的数据
        IRestoreData GetRestoreData();

        // 应该在游戏读档时调用
        void Restore(IRestoreData data);
    }

}