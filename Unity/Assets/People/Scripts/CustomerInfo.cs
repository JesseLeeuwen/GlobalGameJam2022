using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

using TMPro;

using Utilities.Events;

public class CustomerInfo : MonoBehaviour, IPointerClickHandler
{
    public EventAsset OnNewCustomerAsset;
    private TextAnimation textAnimation;
    [SerializeField] private EventAsset start;
    [SerializeField] private TextMeshProUGUI name;

    void Awake()
    {
        textAnimation = GetComponentInChildren<TextAnimation>();
        OnNewCustomerAsset.AddListener( OnNewCustomer );        

        gameObject.SetActive( false );
    }
    
    public void OnNewCustomer( object data )
    {
        gameObject.SetActive( true );
        Customer customer = (Customer)data;

        name.text = customer.name;
        string story = string.Empty;
        for(int i = 0; i < customer.effects.Count; ++i) 
        {
            story += customer.effects[i].Description;
            story += "\n";
        }

        textAnimation.Animate( story );
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // start
        Continue();
    }

    public void Continue()
    {
        start.Invoke(null);
        gameObject.SetActive( false );
    }
}
