using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

using Utilities.Events;

public class OnEventAsset : MonoBehaviour
{
    [SerializeField] private EventAsset eventAsset;
    [SerializeField] private UnityEvent OnEventTriggers;

    void OnEnable()
    {
        eventAsset.AddListener( OnEventAssetTriggered );
    }

    void OnDisable()
    {
        eventAsset.RemoveListener( OnEventAssetTriggered );
    }

    void OnEventAssetTriggered(object arg)
    {
        OnEventTriggers.Invoke();
    }
}
