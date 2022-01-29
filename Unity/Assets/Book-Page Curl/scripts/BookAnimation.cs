using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;

public class BookAnimation : MonoBehaviour, IPointerClickHandler
{
    public Animator animator;

    public void OnPointerClick(PointerEventData eventData)
    {
        animator.SetBool("Active", !animator.GetBool("Active"));
    }
}
