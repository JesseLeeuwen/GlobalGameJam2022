using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using FMODUnity;

[CreateAssetMenu( menuName = "Ingredient")]
public class Ingredient : ScriptableObject
{
    public Sprite Sprite;
    public float Cost;  
    
    [EventRef]
    public string UsageAudio;  
}
