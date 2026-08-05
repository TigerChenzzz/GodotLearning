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
            drawableTexture.Setup(width, height, format, color, useMipmaps);
        }
        #endregion
        #region 使用
        #region DrawableTexture2D 可以直接作为 Texture2D 使用
        {
            GetA(out Sprite2D sprite);
            sprite.Texture = drawableTexture;
        }
        #endregion
        #endregion
    }
}
