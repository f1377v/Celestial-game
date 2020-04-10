using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star {
    public static int MinFuel = 0;
    public static int MaxFuel = 999_999_999;

    public static int MinCurrency = 0;
    public static int MaxCurrency = 999_999_999;

    public static int Mass {
        set {
            PlayerPrefs.SetInt(Login.Username + ".mass", value);
        }
        
        get {
            if (!PlayerPrefs.HasKey(Login.Username + ".mass")) {
                PlayerPrefs.SetInt(Login.Username + ".mass", 30);
            } 
            return PlayerPrefs.GetInt(Login.Username + ".mass");
        }
    }

    public static int Fuel {
        set {
            if (MinFuel <= value && value <= MaxFuel){
                PlayerPrefs.SetInt(Login.Username + ".fuel", value);
            }
        }

        get {
            if (!PlayerPrefs.HasKey(Login.Username + ".fuel")) {
                PlayerPrefs.SetInt(Login.Username + ".fuel", 100);
            } 
            return PlayerPrefs.GetInt(Login.Username + ".fuel");
        }
    }
    
    public static int Currency {
        set {
            if (MinCurrency <= value && value <= MaxCurrency) {
                PlayerPrefs.SetInt(Login.Username + ".currency", value);
            }
        }

        get {
            if (!PlayerPrefs.HasKey(Login.Username + ".currency")) {
                PlayerPrefs.SetInt(Login.Username + ".currency", 100);
            }
            return PlayerPrefs.GetInt(Login.Username + ".currency");
        }
    }
}