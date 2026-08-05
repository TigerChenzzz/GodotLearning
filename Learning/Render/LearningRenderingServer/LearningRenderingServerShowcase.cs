using Godot;
using System.Collections.Generic;

namespace GodotLearning.Learning.Render.LearningRenderingServer;

public partial class LearningRenderingServerShowcase : Node2D {
    private List<Rid> OwnedRids { get; } = [];
    [Export]
    private Transform2D transform = new(1, 0, 0, 1, 0, 0);
    [Export]
    private Texture2D? texture;

    private Rid dynamicRid;
    public override void _Ready() {
        if (texture == null) {
            GD.PrintErr("texture is null!");
            return;
        }
        dynamicRid = CreateCanvasItem(transform, texture, new(-32, -32, 64, 64));
        RenderingServer.CanvasItemAddSetTransform(dynamicRid, new(1, 0, 0, 1, -22, -22));
        RenderingServer.CanvasItemAddRect(dynamicRid, new(33, 33, 20, 20), Colors.MediumPurple);
        RenderingServer.CanvasItemAddRect(dynamicRid, new(53, 33, 20, 20), Colors.MediumPurple);
        RenderingServer.CanvasItemAddSetTransform(dynamicRid, new(1, 0, 0, 1, 22, 22));
        RenderingServer.CanvasItemAddRect(dynamicRid, new(53, 33, 20, 20), Colors.MediumPurple);
    }

    public override void _Process(double delta) {
        RenderingServer.CanvasItemSetTransform(dynamicRid, transform);
    }

    protected override void Dispose(bool disposing) {
        foreach (var rid in OwnedRids) {
            RenderingServer.FreeRid(rid);
        }
        OwnedRids.Clear();
    }

    private Rid CreateCanvasItem(Transform2D transform, Texture2D texture, Rect2 rect) {
        var rid = RenderingServer.CanvasItemCreate();
        OwnedRids.Add(rid);
        RenderingServer.CanvasItemSetParent(rid, GetCanvasItem());
        RenderingServer.CanvasItemAddTextureRect(rid, rect, texture.GetRid());
        RenderingServer.CanvasItemSetTransform(rid, transform);
        return rid;
    }
}
