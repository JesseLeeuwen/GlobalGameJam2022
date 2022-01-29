using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

using Utilities.Events;

public class Kettle : MonoBehaviour, IDropHandler
{
    // handle ondrop of ingredients x
    // remember ingredients x
    public List<IngredientSlot> Ingredients;
    public RecipeDatabase database;

    // show potion details
    [Header("events")]
    [SerializeField] private EventAsset OnRecipeCrafted;
    [SerializeField] private EventAsset OnDropped;

    // query database for potions 
    public void Craft()
    {
        Recipe recipe = database.GetMatch(Ingredients);
        OnRecipeCrafted.Invoke( recipe );

        Ingredients.Clear();
    }

    public void Clean()
    {
        Ingredients.Clear();
    }

    public void OnDrop(PointerEventData eventData)
    {
        IngredientView view = eventData.pointerDrag.GetComponent<IngredientView>();
        Ingredient ingredient = view.ingredient;

        IngredientContainer.AddIngredient( Ingredients, ingredient);
     
        OnDropped.Invoke( view.ingredient );
        view.Disolve();
    }
}
