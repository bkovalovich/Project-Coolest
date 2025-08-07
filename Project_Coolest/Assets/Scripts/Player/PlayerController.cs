using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Player player; 
    //[SerializeField] PlayerInput playerInput;
    private PlayerInputAction inputActions;
    private InputAction moveAction, craftAction; 

    public Vector2 CurrentMovement { get; set; }

    private void Awake() {
        player = GetComponent<Player>(); 
        inputActions = new PlayerInputAction(); 
        inputActions.Player.Enable();
    }
    private void OnEnable() {
        Subscribe();
    }
    private void OnDisable() {
        Unsubscribe(); 
    }
    private void Subscribe() {
        moveAction = inputActions.FindAction("Move");
        moveAction.performed += OnMove; 
        moveAction.canceled += OnMoveCancel;

        craftAction = inputActions.FindAction("Craft");
        craftAction.performed += OnCraft; 
    }
    private void Unsubscribe() {
        moveAction.performed -= OnMove;
        moveAction.canceled -= OnMoveCancel;

        craftAction.performed += OnCraft;
        inputActions?.Player.Disable();
    }

    private void OnMove(InputAction.CallbackContext context) {
        CurrentMovement = context.ReadValue<Vector2>();
    }
    private void OnMoveCancel(InputAction.CallbackContext context) {
        CurrentMovement = Vector2.zero;
    }
    private void OnCraft(InputAction.CallbackContext context) {
        player.set.Craft(); 
        //player.inventory.CraftFromSet(); 
    } 
}

