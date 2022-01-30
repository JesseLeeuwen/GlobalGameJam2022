using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using FMODUnity;

[CreateAssetMenu(menuName = "Effect")]
public class Effect : ScriptableObject
{
    [TextArea(3, 6)]
    public string Description;
    [EventRef]
    public string revealAudio;
}
