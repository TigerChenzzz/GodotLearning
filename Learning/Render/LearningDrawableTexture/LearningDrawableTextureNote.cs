using Godot;
using System;
using static GodotLearning.Helpers.EasyShowcase;

namespace GodotLearning.Learning.Render.LearningDrawableTexture;

public class LearningDrawableTextureNote {
    public static Type TheType { get; } = typeof(DrawableTexture2D);

    public static void SimpleUsage() {
        DrawableTexture2D drawableTexture = new();
        #region 初始化
        {
            #region args
            int width = 100;
            int height = 100;
            DrawableTexture2D.DrawableFormat format = DrawableTexture2D.DrawableFormat.Rgba8;
            Color? color = Colors.Red; // 初始颜色, 默认 null
            bool useMipmaps = false; // 是否使用 Mipmap, 默认 false
            #endregion
            drawableTexture.Setup(width, height, format);
            drawableTexture.Setup(width, height, format, color, useMipmaps);

            // 也可单独修改一些东西
            drawableTexture.SetFormat(format);
            drawableTexture.SetUseMipmaps(useMipmaps);
        }
        #endregion
        #region DrawableTexture2D 可以直接作为 Texture2D 使用
        {
            GetA(out Sprite2D sprite);
            sprite.Texture = drawableTexture;
        }
        #endregion
        #region 绘制 - BlitRect
        {
            #region args
            Rect2I rect = new(4, 4, 10, 10);
            GetA(out Texture2D source);
            Color? modulate = null; // 默认, 表示白色
            int mipmap = 0; // 默认
            Material? material = null; // 默认
            #endregion
            drawableTexture.BlitRect(rect, source);
            drawableTexture.BlitRect(rect, source, modulate, mipmap, material);
        }
        #endregion
    }
}
