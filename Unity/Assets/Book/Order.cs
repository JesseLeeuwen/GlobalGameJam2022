using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Order : MonoBehaviour
{
    [SerializeField] private List<Effect> TabOrder;
    [SerializeField] private int current;

    [SerializeField] private Tab left;
    [SerializeField] private Tab right;

    void Start()
    {
        Refresh();
    }

    public void To(Effect effect)
    {
        current = TabOrder.FindIndex( x => x == effect );
        Refresh();
    }


    void Refresh()
    {
        // loop current
        if( current < 0 )
            current = TabOrder.Count - current;

        current = current % TabOrder.Count;

        // show left
        left.effect = TabOrder[current];
        left.Refresh();

        //show right
        if( current + 1 < TabOrder.Count)
            right.effect = TabOrder[current + 1];
        else
            right.effect = null;
        
        right.Refresh();
    }
}
