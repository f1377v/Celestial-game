using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalEvents: MonoBehaviour {

    public static int mass;
    public static int fuel;

    void Start() {
        DontDestroyOnLoad(this.gameObject); // Keep this object loaded throughout all scenes

        float secondsToMakeFirstCall = 0f;
        float secondsBetweenCalls = 5f;
        InvokeRepeating("DeteriorateStar", secondsToMakeFirstCall, secondsBetweenCalls);
    }

    void DeteriorateStar() {
        Star.Fuel -= 1;
    }

}
