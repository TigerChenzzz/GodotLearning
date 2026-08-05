using Godot;
using System;
using static GodotLearning.Helpers.EasyShowcase;

namespace GodotLearning.Documents.Godot;

public class Document_Image {
    public static Type TheType { get; } = typeof(Image);

    private static Image? image;

    public static void Showcase() {
        #region 凭空创建
        {
            int width = 1;
            int height = 1;
            bool useMipmaps = false;
            Image.Format format = Image.Format.Rgb8;
            image = Image.CreateEmpty(width, height, useMipmaps, format);
            byte[] data = [255, 0, 0]; // rgb8 单格红色
            image = Image.CreateFromData(width, height, useMipmaps, format, data);
        }
        #endregion
        #region 转为 Texture
        {
            ImageTexture texture = ImageTexture.CreateFromImage(image);
            Use(texture);
        }
        #endregion
    }
}
