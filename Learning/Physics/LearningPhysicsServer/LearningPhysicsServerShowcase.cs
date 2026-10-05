using Godot;

namespace GodotLearning.Learning.Physics.LearningPhysicsServer;

public partial class LearningPhysicsServerShowcase : Node2D {
    [Export]
    private RigidBody2D? _player;
    private Transform2D _transform;
    [Export]
    public Transform2D TheTransform {
        get => _transform;
        set {
            _transform = value;
            if (_renderRid.IsValid) {
                RenderingServer.CanvasItemSetTransform(_renderRid, _transform);
            }
            if (_physicsRid.IsValid) {
                PhysicsServer2D.BodySetState(_physicsRid, PhysicsServer2D.BodyState.Transform, _transform);
            }
        }
    }
    private void UpdatePositionByPhysics(Transform2D transform) {
        _transform = transform;
        if (_renderRid.IsValid) {
            RenderingServer.CanvasItemSetTransform(_renderRid, _transform);
        }
    }
    private Rid _renderRid;
    private Rid _physicsRid;
    private Rid _spaceRid;
    private Rid _shapeRid;
    bool _isSpaceRidCreated;
    public override void _Ready() {
        _renderRid = RenderingServer.CanvasItemCreate();
        RenderingServer.CanvasItemAddRect(_renderRid, new Rect2(-50, -50, 100, 100), Colors.Red);
        RenderingServer.CanvasItemSetParent(_renderRid, GetCanvasItem());

        if (_player == null) {
            _spaceRid = PhysicsServer2D.SpaceCreate();
            _isSpaceRidCreated = true;
        }
        else {
            _spaceRid = PhysicsServer2D.BodyGetSpace(_player.GetRid());
        }
        _physicsRid = PhysicsServer2D.BodyCreate();
        _shapeRid = PhysicsServer2D.RectangleShapeCreate();
        PhysicsServer2D.ShapeSetData(_shapeRid, new Vector2(50, 50));
        PhysicsServer2D.BodyAddShape(_physicsRid, _shapeRid);
        PhysicsServer2D.BodySetParam(_physicsRid, PhysicsServer2D.BodyParameter.GravityScale, 0f);
        PhysicsServer2D.BodySetMode(_physicsRid, PhysicsServer2D.BodyMode.Rigid);
        PhysicsServer2D.BodySetStateSyncCallback(_physicsRid, new Callable(this, MethodName.PhysicsStatSync));

        PhysicsServer2D.BodySetSpace(_physicsRid, _spaceRid);
    }

    private void PhysicsStatSync(PhysicsDirectBodyState2D state) {
        UpdatePositionByPhysics(state.Transform);
    }

    protected override void Dispose(bool disposing) {
        RenderingServer.FreeRid(_renderRid);
        PhysicsServer2D.FreeRid(_physicsRid);
        if (_isSpaceRidCreated) {
            PhysicsServer2D.FreeRid(_spaceRid);
        }
        PhysicsServer2D.FreeRid(_shapeRid);
        _renderRid = default;
        _physicsRid = default;
    }
}
