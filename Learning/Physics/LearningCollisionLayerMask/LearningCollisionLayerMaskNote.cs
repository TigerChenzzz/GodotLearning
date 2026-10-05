using Godot;
using static GodotLearning.Helpers.EasyShowcase;

namespace GodotLearning.Learning.Physics.LearningCollisionLayerMask;

public class LearningCollisionLayerMaskNote {
    public static void Show() {
        GetA(out CollisionObject2D collisionObject);
        #region 基本使用
        {
            // 所占用的层, 32 位表示 32 层的占用情况
            Use<uint>(collisionObject.CollisionLayer);
            collisionObject.CollisionLayer |= 1 << 5; // 设置第六位为 true
            // 所检测的层, 32 位表示 32 层的检测情况
            Use<uint>(collisionObject.CollisionMask);
            collisionObject.CollisionMask |= 1 << 5;
        }
        #endregion
        #region 单独设置某一位
        {
            Gets(out int layerNumber, out bool value);
            // 单独设置一位的 CollisionLayer 或 CollisionMask, layerNumber 取值为 [1, 32]
            collisionObject.SetCollisionLayerValue(layerNumber, value);
            collisionObject.SetCollisionMaskValue(layerNumber, value);
        }
        #endregion
        #region 每一层的名称
        {
            // 从 layer_1 到 layer_32, 默认为空
            // 3D 则是将 2d_physics 改为 3d_physics
            Use((string)ProjectSettings.GetSetting("layer_names/2d_physics/layer_1"));
            ProjectSettings.SetSetting("layer_names/2d_physics/layer_1", "FirstLayer");
        }
        #endregion
    }
}
