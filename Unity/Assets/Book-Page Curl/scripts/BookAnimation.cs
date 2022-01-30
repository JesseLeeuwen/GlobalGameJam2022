using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

using FMODUnity;

public class BookAnimation : MonoBehaviour, IPointerClickHandler
{
    public Animator animator;
    
    [EventRef] public string BookInteractionSound;

    public void OnPointerClick(PointerEventData eventData)
    {
        FMODUnity.RuntimeManager.PlayOneShot(BookInteractionSound);
        animator.SetBool("Active", !animator.GetBool("Active"));
    }
}
