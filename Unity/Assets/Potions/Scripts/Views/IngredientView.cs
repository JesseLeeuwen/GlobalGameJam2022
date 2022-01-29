using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class IngredientView : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Ingredient ingredient;

    [SerializeField, HideInInspector] private CanvasGroup group;
    [SerializeField, HideInInspector] private RectTransform transform;
    [SerializeField, HideInInspector] private Canvas canvas;

    internal void Disolve()
    {
        
    }

    void OnValidate()
    {
        canvas = GetComponentInParent<Canvas>();
        transform = GetComponent<RectTransform>();
        group = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        group.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        group.blocksRaycasts = true;
    }
}