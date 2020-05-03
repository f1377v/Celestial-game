using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalEvents: MonoBehaviour {

    void Start() {
        DontDestroyOnLoad(this.gameObject); // Keep this object loaded throughout all scenes

        float secondsToMakeFirstCall = 0f;
        float secondsBetweenCalls = 18f;
        InvokeRepeating("DeteriorateStar", secondsToMakeFirstCall, secondsBetweenCalls);
    }

    void DeteriorateStar() {
        Star.Fuel -= 0.05;
    }
}
