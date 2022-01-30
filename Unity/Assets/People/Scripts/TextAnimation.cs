using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

using TMPro;

public class TextAnimation : MonoBehaviour, IPointerClickHandler
{
    public TextMeshProUGUI targetTextObject;
    public Queue<char> textToPush;
    [Range(0, 0.1f)] public float characterDelay;
    
    private string text;

    void Start()
    {
        targetTextObject = GetComponent<TextMeshProUGUI>();
    }

    public void Animate(string text)
    {
        this.text = text;
        targetTextObject.text = string.Empty;

        if( textToPush != null )
            textToPush.Clear();
        
        textToPush = new Queue<char>( text.ToCharArray() );
        
        StartCoroutine( RunAnimation() );
    }

    private IEnumerator RunAnimation()
    {
        WaitForSeconds delay = new WaitForSeconds(characterDelay);
        while( textToPush.Count != 0 )
        {
            targetTextObject.text += textToPush.Dequeue();    
            yield return delay;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if( textToPush.Count != 0 )
        {
            StopAllCoroutines();
            targetTextObject.text = text;
            eventData.Use();
        }
    }
}
