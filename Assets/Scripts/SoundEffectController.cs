using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundEffectController : MonoBehaviour
{
    public AudioSource AudioSource; 

    public List<SoundClipDefinition> soundClipDefinitions;

    public Dictionary<string, SoundClipDefinition> soundClips;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
        soundClips = new Dictionary<string, SoundClipDefinition>(); 
        foreach(var s in soundClipDefinitions)
            soundClips.Add(s.Type, s);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound(string type)
    {
        if (!soundClips.ContainsKey(type))
            return; 


        AudioSource.clip = soundClips[type].Sound; 
        AudioSource.Play(); 
    }
}
