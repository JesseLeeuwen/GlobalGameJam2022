using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class SupplierDisplay : MonoBehaviour
{
    public Supplier supplier;

    [SerializeField] private Color available;
    [SerializeField] private Color notAvailable;

    [SerializeField] private TextMeshProUGUI repField;
    [SerializeField] private GameObject ItemsHolder;
    [SerializeField] private Image itemPrefab;

    [SerializeField, HideInInspector] private Shop shop;

    void OnValidate()
    {
        shop = FindObjectOfType<Shop>();
    }

    void Start()
    {
        repField.text = supplier.repMinimum.ToString();

        for( int i = 0; i < supplier.ingredients.Count; ++i)
        {
            Image img = Instantiate(itemPrefab, ItemsHolder.transform);
            img.sprite = supplier.ingredients[i].Sprite;
        }
    }

    // Update is called once per frame
    void Update()
    {
        repField.color = shop.reputation >= supplier.repMinimum? available : notAvailable;
    }
}
