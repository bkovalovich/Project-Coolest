using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] public string inventoryName;
    [SerializeField] public int inventoryLength;
    [SerializeField] public ItemSlotType slotType; 

    public ItemSlot[] inventory;
    protected Player player; 

    public Item[] GetItems {
        get {
            Item[] temp = new Item[inventoryLength];
            for (int i = 0; i < temp.Length; i++) {
                temp[i] = inventory[i].Item;
                //Debug.Log(temp[i].Name); 
            }
            return temp; 
        }
    }
    protected bool IsFull {
        get {
            bool allFilled = true;
            foreach (ItemSlot item in inventory) {
                if (item.IsEmpty) { allFilled = false; break; }
            }
            return allFilled;
        }
    }

    protected virtual void Awake() {
        player = GetComponent<Player>(); 
        inventory = new ItemSlot[inventoryLength];
        for(int i = 0; i < inventory.Length; i++) {
            inventory[i] = new ItemSlot(null, 0, slotType); 
        }
    }
    public bool AddToInventory(Item item, int amount) {
        bool added = false; 
        for(int i = 0; i < inventory.Length; i++) {
            if (inventory[i].CanPutNewItem || inventory[i].CanPutSameItem(item.Name)) {
                Debug.Log($"can add at {i}");
                inventory[i].AddAmount(item, slotType == ItemSlotType.Numerable ? amount : 0);
                added = true; 
                break;
            }
        }
        DEBUG_PrintInventory(); 
        return added; 
    }
    public bool AddToInventory(Item item) {
        return AddToInventory(item, 1); 
    }
    public void MoveToOtherInventory(int index, int amount, InventoryManager otherInventory) {
        if (inventory[index].IsEmpty) { Debug.Log("empty slot");  return; }
        Item toMove = inventory[index].Remove(amount);
        otherInventory?.AddToInventory(toMove, amount);
        DEBUG_PrintInventory(); 
    }
    public void MoveToOtherInventory(int index, InventoryManager otherInventory) {
        MoveToOtherInventory(index, 1, otherInventory); 
    }
    protected void ClearInventory() {
        foreach(ItemSlot slot in inventory) {
            slot.TrashSlot();
        }
    }

    public void DEBUG_PrintInventory() {
        string s = inventoryName + ": "; 
        for(int i = 0; i < inventory.Length; i++) {
            if (!inventory[i].IsEmpty) {
                s += $"{inventory[i].Item.Name} ({inventory[i].Amount})";
            } else {
                s += "Empty";
            }
            s += i < inventory.Length - 1 ? ", " : "";
        }
        Debug.Log(s);
    }
}
public enum ItemSlotType { 
    Numerable,
    Single
}

public class ItemSlot {
    private Item item;
    public Item Item {
        get { return item; }
    }
    private int amount;
    public int Amount {
        get { return amount; }
        private set {
            if (slotType == ItemSlotType.Single) {
                amount = 0; 
                return; 
            }
            amount += value;
            Mathf.Clamp(amount, 1, RecipeList.maxSlotAmount);
        }
    }
    public ItemSlotType slotType;
    public bool IsEmpty => item == null;
    public bool IsFull { 
        get {
            if (slotType == ItemSlotType.Single) return Amount >= 1; 
            else return Amount >= RecipeList.maxSlotAmount;
        } 
    }
    public bool CanPutNewItem => IsEmpty && !IsFull;
    public bool CanPutSameItem(string s) {
        return item?.Name == s && slotType == ItemSlotType.Numerable; 
    }
    public ItemSlot(Item item, int amount, ItemSlotType slotType) { //init with amount and slotType
        this.slotType = slotType; 
        AddAmount(item, amount);
    }
    public ItemSlot(Item item) { //init as single slot type
        slotType = ItemSlotType.Single;
        AddAmount(item, 0);
    }
    public void AddAmount(Item item, int toAdd) {
        this.item = item;
        Amount = toAdd; 
    }
    public Item Remove(int toRemove) {
        Item temp = item; 

        Amount = -toRemove;
        if(Amount <= 0) {
            TrashSlot();
        }
        return temp; 
    }
    public void TrashSlot() {
        item = null;
        Amount = 0; 
    }
}

