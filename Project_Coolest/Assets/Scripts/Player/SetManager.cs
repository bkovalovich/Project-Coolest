using UnityEngine;
using UnityEngine.Rendering;

public class SetManager : InventoryManager
{

    protected override void Awake() {
        base.Awake();
        slotType = ItemSlotType.Single; 
    }
    public void Craft() {
        if (!IsFull) return; 
        Item crafted = RecipeList.Craft(GetItems);
        player.inventory.AddToInventory(crafted);
        ClearInventory(); 
    }
}
