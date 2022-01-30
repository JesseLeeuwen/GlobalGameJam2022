using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class ShopStatusDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coins;
    [SerializeField] private Image reputation;

    [SerializeField] private Shop shop;

    void OnValidate()
    {
        shop = FindObjectOfType<Shop>();
    }
    
    void Update()
    {
        coins.text = shop.cash.ToString("C").Substring(1) + ",-";
        reputation.fillAmount = shop.reputation / 500;
    }
}
