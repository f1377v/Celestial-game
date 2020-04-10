using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    public float rbgValue = 0.5f;
    public void AdjustAmbientLight (float rbgValue){
        RenderSettings.ambientLight = new Color (rbgValue, rbgValue, rbgValue, 1);
    }
}

