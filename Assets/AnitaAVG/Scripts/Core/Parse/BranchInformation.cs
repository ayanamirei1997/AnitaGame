/*
 * 分支
 * 
 * 'normal'表示普通选项，此时condition必须省略
 *
 * 'jump'表示如果condition返回true，就会直接跳转到目标节点，否则不显示这个选项，此时text必须省略
 * 如果省略condition，则一定会跳转
 * 如果有多个选项是'jump'，则会按顺序测试每个condition，按照第一个返回true的来跳转
 *
 * 'show'表示如果condition返回true，这个选项才会显示
 * 'enable'表示如果condition返回true，这个选项才能点击
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

    public class BranchInformation
    {
        // 分支的内部名称，由 ScriptLoader.RegisterBranch() 自动生成
        // 名称在流程图节点中应该是唯一的
        public readonly string name;

        // 选择此分支的按钮上的文本
        public readonly string text;

        public readonly BranchImageInformation imageInfo;

        public readonly BranchMode mode;
        public readonly LuaFunction condition;

        // 默认分支，用于普通流程图节点
        // 由于默认分支拥有默认名称，因此所有其他分支不应具有名称“default”
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

        // 检查这个分支是否是默认的顺序分支
        public bool IsDefaultValue()
        {
            return Equals(Default);
        }

        // 如果分支信息具有相同的名称，则它们被认为是相等的
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