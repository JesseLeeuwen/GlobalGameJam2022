using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

using Utilities.Events;

public class IngredientView : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Ingredient ingredient;
    [Header("Events")]
    public EventAsset OnNewCustomerAsset;

    [SerializeField, HideInInspector] private Shop shop;

    [SerializeField, HideInInspector] private CanvasGroup group;
    [SerializeField, HideInInspector] private new RectTransform transform;
    [SerializeField, HideInInspector] private Canvas canvas;

    internal void Disolve()
    {
        
    }

    void OnValidate()
    {
        shop = FindObjectOfType<Shop>();
        canvas = GetComponentInParent<Canvas>();
        transform = GetComponent<RectTransform>();
        group = GetComponent<CanvasGroup>();
    }

    void Start()
    {
        OnNewCustomerAsset.AddListener( OnNewCustomer );
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
        transform.anchoredPosition = Vector2.zero;
    }

    public void OnNewCustomer( object data )
    {
        // check supply chain
        group.blocksRaycasts = shop.CanSupply(ingredient );
        group.alpha = group.blocksRaycasts? 1 : 0.5f;
    }
}