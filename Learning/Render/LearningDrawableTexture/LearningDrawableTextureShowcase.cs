using Godot;

namespace GodotLearning.Learning.Render.LearningDrawableTexture;

public partial class LearningDrawableTextureShowcase : Node2D {
    #region Sprite
    [Export, ExportGroup("Ref")]
    private Sprite2D? _sprite;
    public Sprite2D Sprite {
        get {
            if (_sprite == null) {
                _sprite = new() {
                    Name = "Dynamic Sprite"
                };
                AddChild(_sprite);
            }
            return _sprite;
        }
        set => _sprite = value;
    }
    #endregion
    #region DrawButton
    [Export, ExportGroup("Ref")]
    private Button? _drawButton;
    public Button DrawButton {
        get {
            if (_drawButton == null) {
                _drawButton = new() {
                    Name = "Draw Button",
                    Position = new(0, -100),
                    Size = new(50, 30),
                };
                _drawButton.SetAnchorsPreset(Control.LayoutPreset.Center);
                AddChild(_drawButton);
            }
            return _drawButton;
        }
    }
    #endregion
    #region Some Exports
    [Export, ExportGroup("Draw")]
    private Rect2I _drawRect = new(8, 8, 20, 20);
    [Export, ExportGroup("Draw")]
    private Color _drawColor = Colors.Aqua;
    [Export, ExportGroup("Draw")]
    private byte[] _drawImageData = [255, 255, 255];
    #endregion
    private DrawableTexture2D? _drawableTexture;
    public override void _Ready() {
        _drawableTexture = new();
        _drawableTexture.Setup(100, 100, DrawableTexture2D.DrawableFormat.Rgba8);
        Sprite.Texture = _drawableTexture;
        DrawButton.Pressed += DrawButton_Pressed;
    }

    private void DrawButton_Pressed() {
        if (_drawableTexture == null) {
            GD.PrintErr("Drawable Texture is null!");
            return;
        }
        using var sourceImage = Image.CreateFromData(1, 1, false, Image.Format.Rgb8, _drawImageData);
        using var imageTexture = ImageTexture.CreateFromImage(sourceImage);
        _drawableTexture.BlitRect(_drawRect, imageTexture, _drawColor);
        GD.Print("draw a rect");
    }
}
