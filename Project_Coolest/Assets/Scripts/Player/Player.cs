using System;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] public PlayerStatsSO stats;
    private Player_WalkingState walkingState;
    private PlayerState currentState;

    public InventoryManager inventory;
    public SetManager set;
    public int currentIndex = 0; 

    private void Awake() {
        walkingState = GetComponent<Player_WalkingState>();
        inventory = GetComponent<InventoryManager>();
        set = GetComponent<SetManager>(); 
    }
    private void Start() {
        currentState = walkingState; 
    }
    private void Update() {
        currentState?.FrameUpdate(); 
        if (Input.GetKeyDown(KeyCode.Y)) {
            inventory.MoveToOtherInventory(currentIndex, set);
        }
        if (Input.GetKeyDown(KeyCode.U)) {
            inventory.DEBUG_PrintInventory();
            set.DEBUG_PrintInventory();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            ChangeIndex(true);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow)) {
            ChangeIndex(false);
        }
    }
    private void ChangeIndex(bool upOrDown) {
        currentIndex += upOrDown ? 1 : -1;
        currentIndex = Mathf.Clamp(currentIndex, 0, inventory.inventoryLength - 1);
        Debug.Log($"Index: {currentIndex}");
    }
    private void FixedUpdate() {
        currentState?.PhysicsUpdate();
    }

}
