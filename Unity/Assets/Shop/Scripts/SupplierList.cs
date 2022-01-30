using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupplierList : MonoBehaviour
{
    [SerializeField, HideInInspector] private Shop shop;
    [SerializeField] private RectTransform supplierContainer;
    [SerializeField] private SupplierDisplay supplierPrefab;

    [SerializeField] private RectTransform PanelContainer;
    [SerializeField] private float openHeight;
    [SerializeField] private float closedHeight;

    void OnValidate()
    {
        shop = FindObjectOfType<Shop>();
    }

    IEnumerator Start()
    {
        yield return new WaitForEndOfFrame();

        float height = 0;
        for( int i = 0; i < shop.Suppliers.Count; ++i)
        {
            SupplierDisplay display = Instantiate(supplierPrefab, supplierContainer);
            height += ((RectTransform)display.transform).sizeDelta.y;
            display.supplier = shop.Suppliers[i];
        }

        Vector2 size = new Vector2( supplierContainer.sizeDelta.x, height);
        supplierContainer.sizeDelta = size;
    }

    public void SetActive(bool active)
    {
        if( active )
        {
            PanelContainer.sizeDelta = new Vector2(
                PanelContainer.sizeDelta.x, closedHeight
            );
        }
        else
        {
            PanelContainer.sizeDelta = new Vector2(
                PanelContainer.sizeDelta.x, openHeight
            );
        }
    }
}
