using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star {
    private static int MinFuel = 0;
    private static int MaxFuel = 999_999_999;
    private static int MinCurrency = 0;
    private static int MaxCurrency = 999_999_999;


    public static double Mass {
        set {
            string Mass_value_String = value.ToString(); 
            PlayerPrefs.SetString(Login.Username + ".mass", Mass_value_String);
        }
        
        get {
            if (!PlayerPrefs.HasKey(Login.Username + ".mass")) {
                PlayerPrefs.SetString(Login.Username + ".mass", "30.0");
            }
            string tempPStr = PlayerPrefs.GetString(Login.Username + ".mass");
            return double.Parse(tempPStr, System.Globalization.CultureInfo.InvariantCulture);
        }
    }

    public static double Fuel {
        set {
            if (MinFuel <= value && value <= MaxFuel){
                string Fuel_value_String = value.ToString();
                PlayerPrefs.SetString(Login.Username + ".fuel", Fuel_value_String);
            }
        }

        get {
            if (!PlayerPrefs.HasKey(Login.Username + ".fuel")) {
                PlayerPrefs.SetString(Login.Username + ".fuel", "100.0");
            } 
            string tempPStr = PlayerPrefs.GetString(Login.Username + ".fuel");
            return double.Parse(tempPStr, System.Globalization.CultureInfo.InvariantCulture);
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
                PlayerPrefs.SetInt(Login.Username + ".currency", 400);
            }
            return PlayerPrefs.GetInt(Login.Username + ".currency");
        }
    }
}