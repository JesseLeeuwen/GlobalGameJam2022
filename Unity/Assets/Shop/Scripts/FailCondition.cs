using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Utilities.Events;

public class FailCondition : MonoBehaviour
{
    [SerializeField] private Shop shop;
    [SerializeField] private EventAsset onNewCustomer;
    [SerializeField] private EventAsset OnGameOver;

    void Start()
    {
        onNewCustomer.AddListener( OnNewCustomer );
    }

    private void OnNewCustomer( object data )
    {
        List<IngredientSlot> options = new List<IngredientSlot>();
        for( int i = 0; i < shop.Suppliers.Count; ++i )
        {
            if( shop.Suppliers[i].repMinimum < shop.reputation )
            {
                Supplier supplier = shop.Suppliers[i];
                for( int x = 0; x <supplier.ingredients.Count; ++x )
                    IngredientContainer.AddIngredient( options,supplier.ingredients[x] );
            }
        }

        if( options.Count < 3 )
            OnGameOver.Invoke( null );
    }
}
