using System.Runtime.CompilerServices;
using UnityEngine;

public class Item {
    protected string itemName; 
    public string Name {
        get {
            if (itemName == null) {
                return "";
            }
            return itemName;
        }
    }

    public Item(string itemName) {
        this.itemName = itemName; 
    }
}

public class Weapon : Item {
    private float attack; 
    public Weapon(string itemName, float attack) : base(itemName){
        this.attack = attack; 
    }
}

public class Food : Item {
    private float healthRecover; 
    public Food(string itemName, float healthRecover) : base(itemName) {
        this.healthRecover = healthRecover; 
    }
}

public class Clothing : Item {
    private float coldResist; 
    public Clothing(string itemName, float coldResist) : base(itemName) {
        this.coldResist = coldResist; 
    }
}