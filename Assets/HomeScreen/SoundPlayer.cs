using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public void Play_BackSound(){
        AudioManager audioManager = GetComponent<AudioManager>();
        audioManager.Play("Back");
    }

    public void Play_ClickSound(){
        AudioManager audioManager = GetComponent<AudioManager>();
        audioManager.Play("Click");        
    }
}
