using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManager instance;
    
    void Awake(){
        // if there is no instance in the scene set the instance equal to this object
        if (instance == null){
            instance = this;
        }
        // if there is a instance on the scene destroy this game object
        else {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
        foreach (Sound s in sounds)
        {
            s.set_AudioSource(gameObject.AddComponent<AudioSource>());
            s.set_SourceLoop();
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
