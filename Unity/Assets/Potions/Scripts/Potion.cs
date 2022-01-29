using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Potion")]
public class Potion : ScriptableObject
{
    public string Name;
    public Sprite sprite;

    // effects
    public List<Effect> cures;
    public List<Effect> causes;
}