using UnityEngine;

public class ItemPickup : MonoBehaviour {
    [SerializeField] ItemSO itemSO;
    [SerializeField] int amount = 1;

    private void OnTriggerEnter(Collider other) {
       // Debug.Log("entered");
        InventoryManager temp = other.gameObject.GetComponent<InventoryManager>();
        if (temp != null) {
            temp.AddToInventory(new Item(itemSO.itemName), amount);
            Destroy(gameObject);
        }
    }
}
