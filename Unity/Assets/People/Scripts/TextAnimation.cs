using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class TextAnimation : MonoBehaviour
{
    public TextMeshProUGUI targetTextObject;
    public Queue<char> textToPush;

    void Start()
    {
        targetTextObject = GetComponent<TextMeshProUGUI>();
    }

    public void Animate(string text)
    {
        targetTextObject.text = text;
    }
}
