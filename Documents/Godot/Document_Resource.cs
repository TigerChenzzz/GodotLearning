using Godot;
using System;
using static GodotLearning.Helpers.EasyShowcase;

namespace GodotLearning.Documents.Godot;

public class Document_Resource {
    public static Type TheType { get; } = typeof(Resource);

    private static Resource? resource;

    public static void Showcase() {
        #region 加载
        {
            var path = "res://Prefabs/GameManager.tscn";
            var uidPath = "uid://b6hb5ueqdsuuq";
            resource = GD.Load(path);
            resource = GD.Load(uidPath);
            resource = GD.Load<PackedScene>(path); // 可以指定资源的具体类型
        }
        #endregion
        #region 各属性
        {
            #region ResourcePath
            // 资源路径
            // 如 res://Resources/Items/a1.tres
            // 若是内嵌资源则形式如 res://Resources/Items/a1.tres::Resource_4v1xe
            Use(resource.ResourcePath);
            #endregion
            #region ResourceSceneUniqueId
            // 当内嵌在一个场景或者资源中时为它的独特 ID, 否则为空
            // 形如 Resource_4v1xe
            Use(resource.ResourceSceneUniqueId);
            #endregion
            #region ResourceLocalToScene
            // 对于每次实例化场景时, 是否复制一遍此资源
            Use(resource.ResourceLocalToScene);
            #endregion
            #region ResourceName
            Use(resource.ResourceName);
            #endregion
        }
        #endregion
    }
}
