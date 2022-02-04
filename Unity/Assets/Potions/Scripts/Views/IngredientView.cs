using System.Collections;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

using FMODUnity;

using Utilities.Events;

public class IngredientView : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Ingredient ingredient;
    
    [SerializeField, EventRef] private string grabAudio;

    [Header("Events")]
    public EventAsset OnNewCustomerAsset;


    [SerializeField, HideInInspector] private Shop shop;

    [SerializeField, HideInInspector] private CanvasGroup group;
    [SerializeField, HideInInspector] private new RectTransform transform;
    [SerializeField, HideInInspector] private Canvas canvas;

   [SerializeField] private Image image;

    internal void Disolve()
    {
        // play drop effect
    }

    void OnValidate()
    {
        shop = FindObjectOfType<Shop>();
        canvas = GetComponentInParent<Canvas>();
        transform = GetComponent<RectTransform>();
        group = GetComponent<CanvasGroup>();
    }

    IEnumerator Start()
    {
        OnNewCustomerAsset.AddListener( OnNewCustomer );
        yield return new WaitForEndOfFrame();
        image.sprite = ingredient.Sprite;
        group.alpha = 0;
        image.enabled = true;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        group.blocksRaycasts = false;
        group.alpha = 1;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        group.blocksRaycasts = true;
        group.alpha = 0;
        transform.anchoredPosition = Vector2.zero;
    }

    public void OnNewCustomer( object data )
    {
        // check supply chain
        group.blocksRaycasts = shop.CanSupply(ingredient );
    }
}