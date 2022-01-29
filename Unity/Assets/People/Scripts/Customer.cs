using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Customer")]
public class Customer : ScriptableObject
{
    public Sprite sprite;

    public List<Effect> effects;
}
