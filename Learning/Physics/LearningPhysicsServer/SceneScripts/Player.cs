using Godot;

namespace GodotLearning.Learning.Physics.LearningPhysicsServer.SceneScripts;

public partial class Player : RigidBody2D {
    [Export]
    private float _maxSpeed = 500;
    [Export]
    private float _accelarate = 1000;
    public override void _PhysicsProcess(double delta) {
        var vector = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
        var oldVelocity = LinearVelocity;
        var velocity = vector * _maxSpeed;
        var velocityDelta = velocity - oldVelocity;
        var velocityChange = _accelarate * (float)delta;
        var lengthSq = velocityDelta.LengthSquared();
        if (lengthSq <= velocityChange * velocityChange) {
            LinearVelocity = velocity;
        }
        else {
            LinearVelocity += velocityDelta * (velocityChange / Mathf.Sqrt(lengthSq));
        }
    }
}
