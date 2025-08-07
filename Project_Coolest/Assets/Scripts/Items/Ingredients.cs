using System.Linq;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Ingredients {
    private Item[] items;

    private string ID = "";
    public string GetID { get { return ID; } }
    public bool IsEmpty { get { return items.Length <= 0;  } }



    public Ingredients(ItemSO[] itemSOs) {
        items = new Item[RecipeList.maxIngredients];
        Debug.Log(items.Length);
        for (int i = 0; i < items.Length; i++) {
             items[i] = new Item(itemSOs[i].name);
        }
        OrganizeItems();
    }
    public Ingredients(Item[] items) {
        this.items = new Item[RecipeList.maxIngredients];
        for (int i = 0; i < this.items.Length; i++) {
            this.items[i] = items[i];
        }
        OrganizeItems();
    }
    private void OrganizeItems() {
        //items = items.OrderBy(i => i.Name).ToArray();
        Array.Sort(items, (x, y) => (x.Name).CompareTo(y.Name));
        ID = CreateID;
        Debug.Log(ID);
    }
    public string CreateID {
        get {
            string s = "";
            for (int i = 0; i < items.Length; i++) {
                s += items[i].Name;
                s += i < items.Length - 1 ? "," : "";
            }
            return s;
        }
    }

    public bool Check(Item[] items) {
        return true;
    }
}
