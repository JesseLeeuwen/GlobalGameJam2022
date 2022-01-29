using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class IngredientSlot : IEquatable<IngredientSlot>
{
    public Ingredient ingredient;
    public int amount;

    public bool Equals(IngredientSlot other)
    {
        return other.ingredient == ingredient && other.amount == amount;
    }

    public override bool Equals(object obj) => Equals(obj as IngredientSlot);
    public override int GetHashCode() => (ingredient.name).GetHashCode();
}

public class IngredientContainer
{
    public static void AddIngredient(List<IngredientSlot> ingredients, Ingredient ingredient)
    {
        IngredientSlot slot = ingredients.Find( x => x.ingredient == ingredient );
        if( slot != null )
        {
            ++slot.amount;
            return;
        }

        ingredients.Add( new IngredientSlot{ingredient = ingredient, amount = 1});
    }
}