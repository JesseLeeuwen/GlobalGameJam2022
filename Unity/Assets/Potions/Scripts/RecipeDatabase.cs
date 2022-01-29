using System.Linq;
using System.Collections;
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

    public Recipe GetMatch( List<Ingredient> ingredients )
    {
        foreach( Recipe recipe in recipes )
        {
            IEnumerable<Ingredient> diffQuery = recipe.ingredients.Except( ingredients );
            IEnumerable<Ingredient> diffInQuery = ingredients.Except( recipe.ingredients );

            if( diffQuery.Count() == 0 && diffInQuery.Count() == 0 )
            {
                return recipe;
            }
        }

        return null;
    }
}
