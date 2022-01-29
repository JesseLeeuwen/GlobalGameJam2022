using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Utilities.Events;

public class Shop : MonoBehaviour
{
    public float cash;
    public float reputation;

    public Customer CurrentCustomer;
    [SerializeField] private People people;
    [SerializeField] private List<Supplier> suppliers;
    
    [Header("Events")]
    [SerializeField] private EventAsset OnNewCustomer;
    [SerializeField] private EventAsset OnIngredientUsedAsset;

    void Start()
    {
        suppliers = new List<Supplier>(Resources.LoadAll<Supplier>("/"));

        OnIngredientUsedAsset.AddListener( OnIngredientUsed );

        CurrentCustomer = people.GetNext();
        OnNewCustomer.Invoke( CurrentCustomer );
    }

    private void OnIngredientUsed( object data )
    {
        Ingredient ingredient = (Ingredient)data;
        cash -= ingredient.Cost;
    }

    internal bool CanSupply(Ingredient ingredient)
    {
        return suppliers.Find(x => x.CanSupply( ingredient, reputation)) != null;
    }
}
