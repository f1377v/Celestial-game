using UnityEngine.Audio;
using UnityEngine;
[System.Serializable]
public class Sound {
    private AudioSource source;
    public AudioClip clip;

    public string name;

    public string type;

    public void set_AudioSource(AudioSource source){
        this.source = source;
        this.source.clip = this.clip;
        if (this.type == "music"){
            this.source.volume = 0.4f;
        }
        else if (this.type == "effect"){
             this.source.volume = 1.0f;           
        }
    }
    public void set_SourceVolume(float volume){
        this.source.volume = volume;
    } 
    public void play(){
        //Play() used below is a built in function for the type AudioSource
        this.source.Play();
    }
}