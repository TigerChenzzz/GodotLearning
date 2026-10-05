using System;
using System.Collections.Generic;

namespace GodotLearning.Learning;

public class Catalog {
    public static Dictionary<string, Type> RenderingCatogory { get; } = new() {
        ["可绘制图片"] = typeof(Render.LearningDrawableTexture.LearningDrawableTextureNote),
        ["RenderingServer"] = typeof(Render.LearningRenderingServer.LearningRenderingServerNote),
    };

    public static Dictionary<string, Type> PhysicsCatogory { get; } = new() {
        ["LayerMask"] = typeof(Physics.LearningCollisionLayerMask.LearningCollisionLayerMaskNote),
        ["PhysicsServer"] = typeof(Physics.LearningPhysicsServer.LearningPhysicsServerNote),
    };

    public static void TestFunction() {

    }
}
