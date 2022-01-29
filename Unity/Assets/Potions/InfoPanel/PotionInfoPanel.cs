using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using  Utilities.Events;

public class PotionInfoPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI potionName;
    [SerializeField] private EventAsset onPotionCraft;

    [SerializeField] private RectTransform CuresHolder;
    [SerializeField] private RectTransform CausesHolder;
    [SerializeField] private GameObject effectTextPrefab;

    void Start()
    {
        onPotionCraft.AddListener( OnPotionCraft );
    }

    public void Refresh( Potion potion )
    {
        potionName.text = potion.name;

        FillList(CuresHolder, "Cures", potion.cures);
        FillList(CausesHolder, "Causes", potion.causes);
    }

    private void FillList(RectTransform holder, string name, List<Effect> effects)
    {
        for( int i = holder.childCount -1; i > 0; --i)
        {
            Destroy( holder.GetChild( i). gameObject );
        }

        for( int i = 0; i < effects.Count; ++i )
        {
            GameObject effectInfo = Instantiate( effectTextPrefab, holder );
            TextMeshProUGUI text = effectInfo.GetComponent<TextMeshProUGUI>();
            text.text = effects[i].name;
        }   
    }

    private void OnPotionCraft( object data )
    {
        Refresh( ((Recipe)data).potion );
    }
}
