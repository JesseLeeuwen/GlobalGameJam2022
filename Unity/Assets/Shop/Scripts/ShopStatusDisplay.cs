using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class ShopStatusDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coins;
    [SerializeField] private TextMeshProUGUI reputation;

    [SerializeField] private Shop shop;

    void OnValidate()
    {
        shop = FindObjectOfType<Shop>();
    }
    
    void Update()
    {
        coins.text = shop.cash.ToString();
        reputation.text = shop.reputation.ToString();
    }
}
