using GodotLearning.Learning.Render.LearningDrawableTexture;
using System;
using System.Collections.Generic;

namespace GodotLearning.Learning;

public class Catalog {
    public static Dictionary<string, Type> RenderingCatogory { get; } = new() {
        ["可绘制图片"] = typeof(LearningDrawableTextureNote),
    };

    public static void TestFunction() {

    }
}
