using UnityEngine;
using System.Collections.Generic;
using System.Linq;


public class Recipe {
    private Ingredients ingredients;
    public Ingredients Ingredients => ingredients;
    private Item result;
    public Item Result => result; 
    public Recipe(Ingredients ingredients, Item result) {
        this.ingredients = ingredients; 
        this.result = result; 
    }
    public override string ToString() {
        return $"{ingredients.GetID} = {result.Name}";
    }
}

