using UnityEngine;

[CreateAssetMenu(menuName = "SO/Recipe")]
public class RecipeSO : ScriptableObject
{
    [SerializeField] public string recipeName; 
    [SerializeField] public ItemSO[] ingredients;
    [SerializeField] public ItemSO result; 
}
