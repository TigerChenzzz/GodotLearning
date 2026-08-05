using Godot;
using System;
using static GodotLearning.Helpers.EasyShowcase;

namespace GodotLearning.Learning.Render.LearningRenderingServer;

public class LearningRenderingServerNote {
    public static Type TheType { get; } = typeof(RenderingServer);

    public static void SimpleUsage() {
        Rid rid = default;
        #region 创建画布项
        rid = RenderingServer.CanvasItemCreate();
        #endregion
        #region 设置各种参数
        {
            #region args
            GetA(out Rid parentRid);
            GetA(out Transform2D transform);
            GetA(out Material material);
            GetA(out Color color);
            bool visible = true;
            #endregion
            RenderingServer.CanvasItemSetParent(rid, parentRid);
            RenderingServer.CanvasItemSetTransform(rid, transform);
            RenderingServer.CanvasItemSetMaterial(rid, material.GetRid());
            RenderingServer.CanvasItemSetModulate(rid, color);
            RenderingServer.CanvasItemSetSelfModulate(rid, color);
            RenderingServer.CanvasItemSetVisible(rid, visible);
        }
        #endregion
        #region 添加图片或图形
        {
            #region args
            GetA(out Texture2D texture);
            GetA(out Color color);
            GetA(out Vector2 pos);
            GetA(out Transform2D transform);
            float radius = 60;
            #endregion
            RenderingServer.CanvasItemAddSetTransform(rid, transform); // 设置即将被画上去的 Transform, 对接下来所有项生效, 直至下一个此方法调用
            Rect2 rect = new(0, 0, texture.GetSize()); // 这里和上面 Transform 都可以设置图片的位移与大小, 此处单位为像素
            RenderingServer.CanvasItemAddTextureRect(rid, rect, texture.GetRid()); // 在此 CanvasItem 上绘制一个图片
            RenderingServer.CanvasItemAddRect(rid, rect, color); // 在此 CanvasItem 上绘制一个矩形
            RenderingServer.CanvasItemAddCircle(rid, pos, radius, color); // 在此 CanvasItem 上绘制一个圆
        }
        #endregion
        #region 不使用时释放
        RenderingServer.FreeRid(rid);
        #endregion

        #region 从一个已有的 CanvasItem 获取 Rid
        {
            GetA(out CanvasItem canvasItem);
            Rid canvasItemRid = canvasItem.GetCanvasItem();
            Use(canvasItemRid);
        }
        #endregion
    }
}
