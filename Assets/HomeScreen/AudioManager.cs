using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    
    void Awake(){
        DontDestroyOnLoad(gameObject);
        foreach (Sound s in sounds)
        {
            s.set_AudioSource(gameObject.AddComponent<AudioSource>());
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Play("Happy");
    }
    public void Play(string name){
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.play();
    }
    public void MusicVolume(float volume){
        foreach (Sound s in sounds)
        {
            if (s.type == "music"){
                s.set_SourceVolume(volume);
            }
        }
    }
    public void SoundEffectVolume(float volume){
        foreach (Sound s in sounds)
        {
            if (s.type == "effect"){
                s.set_SourceVolume(volume);
            }
        }
    }
}
