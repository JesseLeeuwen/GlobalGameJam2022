using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeView : MonoBehaviour
{
    public Recipe recipe;
    [SerializeField] private IngredientSlotView prefab;

    void Start()
    {
        for( int i = 0; i < recipe.ingredients.Count; ++i )
        {
            IngredientSlotView ingredient = Instantiate<IngredientSlotView>(prefab, transform);
            ingredient.ingredients = recipe.ingredients;
            ingredient.index = i;
        }
    }
}
