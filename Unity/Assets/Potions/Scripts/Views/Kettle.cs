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

    [FMODUnity.EventRef]
    public string resetAudio;

    public List<IngredientSlotView> views;

    // show potion details
    [Header("events")]
    [SerializeField] private EventAsset OnRecipeCrafted;
    [SerializeField] private EventAsset OnDropped;

    void Start()
    {
        for( int i = 0; i < views.Count; ++i)
        {
            views[i].ingredients = Ingredients;
        }
    }

    // query database for potions 
    public void Craft()
    {
        if( Ingredients.Count == 0 )
            return;

        Recipe recipe = database.GetMatch(Ingredients);
        OnRecipeCrafted.Invoke( recipe );

        Ingredients.Clear();
    }

    public void Clean()
    {
        FMODUnity.RuntimeManager.PlayOneShot(resetAudio);
        Ingredients.Clear();
    }

    public void OnDrop(PointerEventData eventData)
    {
        IngredientView view = eventData.pointerDrag.GetComponent<IngredientView>();
        Ingredient ingredient = view.ingredient;

        FMODUnity.RuntimeManager.PlayOneShot(ingredient.UsageAudio);

        IngredientContainer.AddIngredient( Ingredients, ingredient);
     
        OnDropped.Invoke( view.ingredient );
        view.Disolve();
    }
}
