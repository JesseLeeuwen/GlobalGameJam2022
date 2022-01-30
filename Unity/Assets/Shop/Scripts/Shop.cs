using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using FMODUnity;

using Utilities.Events;

public class Shop : MonoBehaviour
{
    public float cash;
    public float reputation;

    public bool active;
    public float CraftTime;
    public float CurrentTime;

    [SerializeField] private float timeoutPenalty;

    public List<Supplier> Suppliers;
    public Customer CurrentCustomer;
    [SerializeField] private People people;
    
    [Header("Events")]
    [SerializeField] private EventAsset onNewCustomer;
    [SerializeField] private EventAsset onIngredientUsed;
    [SerializeField] private EventAsset onStart;
    [SerializeField] private EventAsset onCraft;
    [SerializeField] private EventAsset onTimeout;

    [Header("Audio")]
    [SerializeField, EventRef] private string NewCustomerAudio;
    [SerializeField, EventRef] private string PotionSold;

    void Start()
    {
        people = Instantiate<People>(people);
        
        Suppliers = new List<Supplier>(Resources.LoadAll<Supplier>("/"));

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
            reputation += timeoutPenalty;
            active = false;
        }
    }

    public void NewCustomer()
    {
        if( CurrentCustomer != null )
        {
            people.ReturnToPool( CurrentCustomer );
        }

        CurrentCustomer = people.GetNext();
        FMODUnity.RuntimeManager.PlayOneShot(NewCustomerAudio);
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
        if( data == null )
            return;

        FMODUnity.RuntimeManager.PlayOneShot(PotionSold);
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
        return Suppliers.Find(x => x.CanSupply( ingredient, reputation)) != null;
    }
}
