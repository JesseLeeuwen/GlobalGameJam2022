using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Utilities.Events;

public class Shop : MonoBehaviour
{
    public float cash;
    public float reputation;

    public bool active;
    public float CraftTime;
    [HideInInspector] public float CurrentTime;

    public Customer CurrentCustomer;
    [SerializeField] private People people;
    [SerializeField] private List<Supplier> suppliers;
    
    [Header("Events")]
    [SerializeField] private EventAsset onNewCustomer;
    [SerializeField] private EventAsset onIngredientUsed;
    [SerializeField] private EventAsset onStart;
    [SerializeField] private EventAsset onCraft;
    [SerializeField] private EventAsset onTimeout;

    void Start()
    {
        people = Instantiate<People>(people);
        
        suppliers = new List<Supplier>(Resources.LoadAll<Supplier>("/"));

        onIngredientUsed.AddListener( OnIngredientUsed );
        onStart.AddListener( OnStart );
        onCraft.AddListener( OnCraft );

        NewCustomer();
    }

    void Update()
    {
        if(!active)
            return;

        CurrentTime += Time.deltaTime;
        if( CurrentTime >= CraftTime )
        {
            onTimeout.Invoke(null);
            active = false;
        }
    }

    public void NewCustomer()
    {
        CurrentCustomer = people.GetNext();
        onNewCustomer.Invoke( CurrentCustomer );
    }

    private void OnStart( object data )
    {
        CurrentTime = 0;
        active = true;
    }

    private void OnCraft(object data)
    {
        Recipe recipe = (Recipe)data;

        cash += recipe.potion.value;
        reputation += recipe.potion.RepChange;
        
        active = false;
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
