using System.Collections.Generic;
using UnityEngine;
using TMPro;
using  Utilities.Events;

public class PotionInfoPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI potionName;
    [SerializeField] private RectTransform CuresHolder;
    [SerializeField] private RectTransform CausesHolder;
    [SerializeField] private GameObject effectTextPrefab;

    [SerializeField, HideInInspector] private CanvasGroup group;
    [SerializeField, HideInInspector] private DelayedEvent reset;

    [Header("Events")]
    [SerializeField] private EventAsset onPotionCraft;
    [SerializeField] private EventAsset onNewCustomer;

    void Start()
    {
        onPotionCraft.AddListener( OnPotionCraft );
        onNewCustomer.AddListener( OnNewCustomer );

        reset = GetComponent<DelayedEvent>();

        group = GetComponent<CanvasGroup>();
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

    private void OnNewCustomer( object data )
    {
        group.alpha = 0;
    }

    private void OnPotionCraft( object data )
    {
        Potion potion = ((Recipe)data).potion;
        if( potion == null )
            return;

        reset.enabled = true;
        group.alpha = 1;
        Refresh( potion );
    }
}
