using UnityEditor;
using UnityEngine;

public abstract class PlayerState : MonoBehaviour
{
    protected Player player;
    protected PlayerController controller;
    protected Rigidbody rb;
    protected PlayerStatsSO PlayerStats => player.stats;
    protected Vector2 MoveInput => controller.CurrentMovement; 
    protected virtual void Awake() {
        player = GetComponent<Player>();
        controller = GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody>();
    }
    public abstract void Enter();
    public abstract void Exit();
    public abstract void PhysicsUpdate();
    public abstract void FrameUpdate();

}
