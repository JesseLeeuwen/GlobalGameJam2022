using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using FMODUnity;
using FMOD.Studio;

public class Music : MonoBehaviour
{
    [SerializeField, EventRef]
    private string MusicEvent;

    private EventInstance musicInstance;

    // Start is called before the first frame update
    void Start()
    {
        musicInstance = FMODUnity.RuntimeManager.CreateInstance( MusicEvent );
        musicInstance.start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
