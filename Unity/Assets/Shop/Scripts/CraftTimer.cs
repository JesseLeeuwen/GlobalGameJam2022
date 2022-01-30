using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftTimer : MonoBehaviour
{
    [SerializeField] private Material material;
    [SerializeField] private Shop shop;

    void Start()
    {
        shop = FindObjectOfType<Shop>();
    }

    // Update is called once per frame
    void Update()
    {
        float progress = shop.CurrentTime / shop.CraftTime;   
        material.SetFloat("_Top", progress);
    }
}
