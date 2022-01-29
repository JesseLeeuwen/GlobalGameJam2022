using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnEnableEvent : MonoBehaviour
{
    [SerializeField] private UnityEvent OnEnabledHandle;
    [SerializeField] private UnityEvent OnDisableHandle;

    void OnEnable()
    {
        OnEnabledHandle.Invoke();
    }

    void OnDisable()
    {
        OnDisableHandle.Invoke();
    }
}
