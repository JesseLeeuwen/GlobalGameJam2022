using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Utilities.Events;

public class IngredientSlotView : MonoBehaviour
{
    public List<IngredientSlot> ingredients;
    public int index;

    [SerializeField] private GameObject amountText;
    private TextMeshProUGUI text;
    [SerializeField] private GameObject graphics;
    [SerializeField] private Image image;

    [Header("Events")]
    [SerializeField] private EventAsset OnDropped;

    void Start()
    {
        text = amountText.GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        IngredientSlot slot = new IngredientSlot(){amount = 0};
        if( ingredients.Count > index)
            slot = ingredients[index];

        graphics.SetActive(slot.amount != 0 );
        amountText.SetActive(slot.amount > 1 );
        text.text = slot.amount.ToString();
        if( slot.amount == 0 )
            return;
        
        image.sprite = slot.ingredient.Sprite;

    }
}
