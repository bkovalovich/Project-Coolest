using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class RecipeManager : MonoBehaviour {
    [SerializeField] RecipeSO[] recipeSOs;
    [SerializeField] ItemSO defaultCraft; 

    private void Awake() {
        RecipeList.SetupMasterList(recipeSOs, defaultCraft);
    }
}
public static class RecipeList {
    public static List<Recipe> recipes = new List<Recipe>();
    public static Item defaultItem; 
    public static readonly int maxIngredients = 3;
    public static readonly int maxSlotAmount = 99;

    public static void SetupMasterList(RecipeSO[] recipeSOs, ItemSO defaultCraft) {
        defaultItem = new Item(defaultCraft.itemName); 
        foreach (RecipeSO recipeSO in recipeSOs) {
            if (recipeSO.ingredients.Length < maxIngredients || recipeSO.result == null) {
                Debug.Log($"{recipeSO.recipeName} is not setup properly.");
                continue;
            }

            Recipe newRecipe = new Recipe(new Ingredients(recipeSO.ingredients), new Item(recipeSO.result.name));
            recipes.Add(newRecipe);
            Debug.Log(newRecipe); 
        }
    }
    public static Item Craft(Item[] items) {
        Ingredients toCheck = new Ingredients(items);
        foreach (Recipe recipe in recipes) {
            if (recipe.Ingredients.GetID == toCheck.GetID) {
                return recipe.Result; 
            }
        }
       return defaultItem; 
    }

}
