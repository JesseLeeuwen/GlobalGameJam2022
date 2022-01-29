using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Kettle : MonoBehaviour, IDropHandler
{
    // handle ondrop of ingredients x
    // remember ingredients x
    public List<Ingredient> Ingredients;
    public RecipeDatabase database;
    // query database for potions 

    // show potion details

    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    public void OnDrop(PointerEventData eventData)
    {
        IngredientView view = eventData.pointerDrag.GetComponent<IngredientView>();
        Ingredient ingredient = view.ingredient;

        view.Disolve();

        Ingredients.Add(ingredient);
    }


}
