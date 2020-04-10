using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{   
    private static int mass;
    private static int fuel;
    public GameObject deathTextBad;
    public GameObject deathTextGood;

    public enum StarType {
        superNova,
        dyingStar,
        startStar,
        redStar, 
        whiteStar,
        purpleStar,
    }

    private const double decr = 0.5;
    // Start is called before the first frame update
    void Start() {
        mass = Star.Mass;
        fuel = Star.Fuel;
        Update();
    }

    // Update is called once per frame
    void Update() {  
        mass = Star.Mass;
        fuel = Star.Fuel;

        if (fuel <= 0) {
            //death of star
            deathTextBad.SetActive(true);
        } else if (fuel == 200) {
            //2nd worst star
            // swapSprite();
        } else if (fuel == 150000){
            //upgrade to red giant
        }
    }

    void swapSprite(int chooseStar) {
        
    }
}
