using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftTimer : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Shop shop;

    void Start()
    {
        slider = GetComponent<Slider>();
        shop = FindObjectOfType<Shop>();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = shop.CurrentTime / shop.CraftTime;   
    }
}
