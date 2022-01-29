using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Utilities.Events;

public class IngredientSlotView : MonoBehaviour
{
    public Kettle kettle;
    public int index;

    [SerializeField] private GameObject amountText;
    private TextMeshProUGUI text;
    [SerializeField] private GameObject graphics;
    [SerializeField] private Image imasge;

    [Header("Events")]
    [SerializeField] private EventAsset OnDropped;

    void Start()
    {
        kettle = FindObjectOfType<Kettle>();
        text = amountText.GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        IngredientSlot slot = new IngredientSlot(){amount = 0};
        if(kettle.Ingredients.Count > index)
            slot = kettle.Ingredients[index];

        graphics.SetActive(slot.amount != 0 );
        amountText.SetActive(slot.amount > 1 );
        text.text = slot.amount.ToString();

        if( slot.amount == 0 )
            return;

        imasge.sprite = slot.ingredient.Sprite;
    }
}
