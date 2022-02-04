using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Utilities.Events;

public class Response : MonoBehaviour
{
    [SerializeField] private EventAsset onCraftEvent;
    [SerializeField] private TextAnimation text;

    [SerializeField] private GameObject container;

    void Start()
    {
        onCraftEvent.AddListener( OnCraft );
    }

    private void OnCraft( object data )
    {
        Potion potion = ((Recipe)data).potion;
        if( potion == null )
            return;
            
        container.SetActive(true);
        text.Animate( potion.Response );
    }
}
