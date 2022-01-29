using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Potion")]
public class Potion : ScriptableObject
{
    public Sprite sprite;
    public float value;
    public float RepChange;

    // effects
    public List<Effect> cures;
    public List<Effect> causes;
}