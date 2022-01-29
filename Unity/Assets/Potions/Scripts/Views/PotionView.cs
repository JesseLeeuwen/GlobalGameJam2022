using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionView : MonoBehaviour
{
    [SerializeField] private Potion potion;

    private new SpriteRenderer renderer;

    void OnValidate()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    public void SetPotion(Potion potion)
    {
        this.potion = potion;
    }
}
