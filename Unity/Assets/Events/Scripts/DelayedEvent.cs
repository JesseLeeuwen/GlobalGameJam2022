using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DelayedEvent : MonoBehaviour
{
    [SerializeField, Range(0.01f, 180)]
    private float delay;

    [SerializeField]
    private UnityEvent unityEvent;

    IEnumerator Start()
    {
        yield return new WaitForSeconds( delay );
        unityEvent.Invoke();
    }

    public void Reset()
    {
        StopAllCoroutines();
        StartCoroutine(Start());
    }

    public void Stop()
    {
        StopAllCoroutines();
    }
}