using UnityEngine;

public class Player_WalkingState : PlayerState {
    private Vector3 velocity;
    protected override void Awake() {
        base.Awake(); 
    }
    public override void Enter() {
    }

    public override void Exit() {
    }

    public override void FrameUpdate() {
    }

    public override void PhysicsUpdate() {
        velocity = new Vector3(PlayerStats.walkSpeed * controller.CurrentMovement.x, 0, PlayerStats.walkSpeed * controller.CurrentMovement.y);
        rb.AddForce(velocity);
    }
}
