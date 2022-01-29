using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

using Utilities.Events;

public class Kettle : MonoBehaviour, IDropHandler
{
    // handle ondrop of ingredients x
    // remember ingredients x
    public List<Ingredient> Ingredients;
    public RecipeDatabase database;

    // show potion details
    [SerializeField] private EventAsset OnRecipeCrafted;


    // query database for potions 
    public void Craft()
    {
        Recipe recipe = database.GetMatch(Ingredients);
        print("crafting: " + recipe);
        OnRecipeCrafted.Invoke( recipe );
    }

    public void OnDrop(PointerEventData eventData)
    {
        IngredientView view = eventData.pointerDrag.GetComponent<IngredientView>();
        Ingredient ingredient = view.ingredient;

        view.Disolve();

        Ingredients.Add(ingredient);
    }


}
