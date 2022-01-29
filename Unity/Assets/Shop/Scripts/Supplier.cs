using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Supplier")]
public class Supplier : ScriptableObject
{
    public List<Ingredient> ingredients;
    public float repMinimum;

    public bool CanSupply(Ingredient ingredient, float currentRep )
    {
        if( currentRep < repMinimum )
            return false;

        return ingredients.Find( x => x == ingredient ) != null;
    }
}
