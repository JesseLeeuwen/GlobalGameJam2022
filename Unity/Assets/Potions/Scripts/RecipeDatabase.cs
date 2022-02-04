using System.Linq;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu( menuName = "RecipeDatabase")]
public class RecipeDatabase : ScriptableObject
{
    public List<Recipe> recipes;

    public void AddRecipe(Recipe recipe)
    {
        recipes.Add(recipe);
    }
    
    public List<Recipe> GetCures(Effect effect)
    {
        return recipes.FindAll(x => x.potion.cures.Contains(effect) );
    }

    public Recipe GetMatch( List<IngredientSlot> ingredients )
    {
        foreach( Recipe recipe in recipes )
        {
            IEnumerable<IngredientSlot> diffQuery = recipe.ingredients.Except( ingredients );
            IEnumerable<IngredientSlot> diffInQuery = ingredients.Except( recipe.ingredients );

            if( diffQuery.Count() == 0 && diffInQuery.Count() == 0 )
            {
                return recipe;
            }
        }

        return null;
    }
}
