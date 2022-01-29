using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Utilities.Events;

public class CustomerInfo : MonoBehaviour
{
    public EventAsset OnNewCustomerAsset;
    private TextAnimation textAnimation;

    void Start()
    {
        textAnimation = GetComponentInChildren<TextAnimation>();

        OnNewCustomerAsset.AddListener( OnNewCustomer );        
    }
    
    public void OnNewCustomer( object data )
    {
        Customer customer = (Customer)data;

        string story = "Hi my name is " + customer.name;
        story += "\n";

        for(int i = 0; i < customer.effects.Count; ++i) 
        {
            story += customer.effects[i].Description;
            story += "\n";
        }

        textAnimation.Animate( story );
    }
}
