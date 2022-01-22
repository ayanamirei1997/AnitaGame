/*
 * 分支信息 branch information
 */

using LuaInterface;

namespace Anita
{
    [ExportCustomType]
    public enum BranchMode
    {
        Normal,
        Jump,
        Show,
        Enable
    }

    [ExportCustomType]
    public class BranchImageInformation
    {
        public readonly string name;
        public readonly float positionX;
        public readonly float positionY;
        public readonly float scale;

        public BranchImageInformation(string name, float positionX, float positionY, float scale)
        {
            this.name = name;
            this.positionX = positionX;
            this.positionY = positionY;
            this.scale = scale;
        }
    }

    // branch information 
    public class BranchInformation
    {
        // branch 的内部 name, 由 ScriptLoader.RegisterBranch() 自动生成
        public readonly string name;

        // 选择这个 branch 的按钮上的 text
        public readonly string text;

        public readonly BranchImageInformation imageInfo;

        public readonly BranchMode mode;
        public readonly LuaFunction condition;

        // 默认的 branch， 用于 normal flow chart nodes 
        // 因为默认的 branch 具有 “default” 的名字， 其他 branch 都不该用 “default‘”
        public static readonly BranchInformation Default = new BranchInformation("default");

        public BranchInformation(string name)
        {
            this.name = name;
        }

        public BranchInformation(string name, string text, BranchImageInformation imageInfo, BranchMode mode,
            LuaFunction condition)
        {
            this.name = name;
            this.text = text;
            this.imageInfo = imageInfo;
            this.mode = mode;
            this.condition = condition;
        }

        // 检查此 branch 是否为 default branch 
        public bool IsDefaultValue()
        {
            return Equals(Default);
        }

        // BranchInformations are considered equal if they have the same name
        // 当且仅当两个 branch 具有同样 name 时，认为两个节点是相同的
        public override bool Equals(object obj)
        {
            return obj is BranchInformation anotherBranch && name.Equals(anotherBranch.name);
        }

        public override int GetHashCode()
        {
            return name.GetHashCode();
        }
    }
}