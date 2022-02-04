using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tab : MonoBehaviour
{
    public Effect effect;
    
    [SerializeField] private TextMeshProUGUI text;

    [SerializeField] private RecipeDatabase database;
    [SerializeField] private RectTransform container;
    [SerializeField] private RecipeView recipeView;

    void Start()
    {
       Refresh(); 
    }

    public void Refresh()
    {
        gameObject.SetActive( effect != null );
        if( effect ==  null )
            return;

        for( int i = container.childCount -1; i >= 0; --i)
        {
            DestroyImmediate( container.GetChild( i). gameObject );
        }

        text.text = effect.name;

        List<Recipe> recipes = database.GetCures(effect);

        for( int i = 0; i < recipes.Count; ++i)
        {
            RecipeView recipe = Instantiate<RecipeView>(recipeView, container);
            recipe.recipe = recipes[i];
        }
    }
}
