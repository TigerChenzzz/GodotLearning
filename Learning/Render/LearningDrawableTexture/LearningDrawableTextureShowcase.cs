using Godot;

namespace GodotLearning.Learning.Render.LearningDrawableTexture;

public partial class LearningDrawableTextureShowcase : Node2D {
    #region Sprite
    [Export]
    private Sprite2D? _sprite;
    public Sprite2D Sprite {
        get {
            if (_sprite == null) {
                _sprite = new();
                AddChild(_sprite);
            }
            return _sprite;
        }
        set => _sprite = value;
    }
    #endregion
    private DrawableTexture2D? _drawableTexture;
    public override void _Ready() {
        _drawableTexture = new();
        _drawableTexture.Setup(100, 100, DrawableTexture2D.DrawableFormat.Rgba8);
        Sprite.Texture = _drawableTexture;
    }
}
