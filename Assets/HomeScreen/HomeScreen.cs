using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;					
public class HomeScreen : MonoBehaviour
{   
    private float timer = 0.0f;

    public GameObject hungerText;
    public GameObject currencyText;
    public GameObject massText;
    public GameObject dyingStar;
    public GameObject startStar;
    public GameObject redStar;
    public GameObject purpleStar;
    public GameObject whiteStar;
    public GameObject FuelBar;
    public GameObject MassBar;
	
	void Start(){
        //Checks how long it has passed since the user last played the game and updates fuel and mass accordingly
        updateState();

        //Upgrades or downgrades the star based on the state of the game 
        upgrade();
	}

    void Update() {

        hungerText.GetComponent<Text> ().text = "" + (int)Star.Fuel;
        FuelBar.GetComponent <Slider> ().value = (int)Star.Fuel;
        currencyText.GetComponent<Text> ().text = " " + Star.Currency;
        massText.GetComponent<Text> ().text = " " + (int)Star.Mass;
        MassBar.GetComponent <Slider> ().value = (int)Star.Mass;

        //Changing the mass based on fuel
        timer = timer + Time.deltaTime;
        if (timer > 189.0f){
            if (25 < Star.Fuel && Star.Fuel < 50){
                Star.Mass = Star.Mass - 0.1;
            }
            
            else if (0 < Star.Fuel && Star.Fuel <= 25){
                Star.Mass = Star.Mass - 0.2;
            }

            else if ((int)Star.Fuel == 0){
                Star.Mass = Star.Mass - 0.3;
            }

            timer = timer - 189.0f;
        };

        upgrade();
    }

    public void Show_Leaderboard(){
        SceneManager.LoadScene("Leaderboard/presentation/Leaderboard");
    }

    public void ShowShop(){
        SceneManager.LoadScene("Shop Agent/Presentation/ShopView");
    }

    public void ShowMinigame() {
        SceneManager.LoadScene("Minigame/Scene/Minigame");
    }
	

    private void updateState(){
        int Seconds = timePassed(); //Finding the difference in terms of seconds
        double period_number = Seconds/360; //Every 360 seconds is considered a period(for user experience purposes)

        //Changing mass accordingly
        double CurrentFuel = Star.Fuel - period_number;  //The fuel is reduced one unit per period

        if (25 < CurrentFuel && CurrentFuel < 50){
            double time_25_50 = (50 - CurrentFuel) * 360;  // Time spent with fuel between 50 to 25 
            double deltaMass = time_25_50 / 1890; //Every 1890 seconds the value of mass changes by one unit when fuel is between 25 and 50
            Star.Mass -= deltaMass;
        }

        if (0 < CurrentFuel && CurrentFuel <= 25){
            double deltaMass = 5 + ((25 - CurrentFuel) * 360) * 2 / 1890; // The change of mass from first interval (25 to 50) is 5 which is added
            Star.Mass -= deltaMass;
        }
    
        if (CurrentFuel < 0){
            double deltaMass = 5 + 10 + ((0 - CurrentFuel) * 360) * 3 / 1890;
            Star.Mass -= deltaMass;
        }

        //Changing the fuel value accordingly    
        if (CurrentFuel < 0 ){  //if the current value is negative set fuel to zero
            Star.Fuel = 0;
        } else {Star.Fuel = CurrentFuel;}  
    }
	
    private int timePassed(){
        //Store the current time when it starts
        DateTime currentDate = System.DateTime.Now;
 
        //Grab the old time from the player prefs as a long
        long temp = Convert.ToInt64(PlayerPrefs.GetString(Login.Username + ".quitTime", currentDate.ToBinary().ToString()));
 
        //Convert the old time from binary to a DataTime variable
        DateTime oldDate = DateTime.FromBinary(temp);

        TimeSpan difference = currentDate.Subtract(oldDate);
        print("Difference: " + difference);
        Double Seconds = difference.TotalSeconds;
        print("Seconds: " + Seconds);
        return (int)Seconds;
	}

    private void upgrade(){
        //if the mass is zero load the gameover scene
        if ( Star.Mass <= 0 ){SceneManager.LoadScene("HomeScreen/gameover");}

        // if the mass is between 0 and 20 activate the dying star and deactivate the previous star (downgrade)
        if ( 0 < Star.Mass && Star.Mass < 20 ) {startStar.SetActive(false);dyingStar.SetActive(true);}

        // if the mass is between 20 and 40 activate the dying star and deactivate the previous star (downgrade and upgarde)
        else if ( 20 <= Star.Mass && Star.Mass < 40) {
            dyingStar.SetActive(false);
            startStar.SetActive(true);
            redStar.SetActive(false);
        }

        else if( 40 <= Star.Mass && Star.Mass < 60 ){
            startStar.SetActive(false);
            redStar.SetActive(true);
            purpleStar.SetActive(false);
        }

        else if( 60 <= Star.Mass && Star.Mass < 80){
            redStar.SetActive(false);
            purpleStar.SetActive(true);
            whiteStar.SetActive(false);
        }

        else if ( 80 <= Star.Mass && Star.Mass < 100){
            purpleStar.SetActive(false);
            whiteStar.SetActive(true);
        }

        else if (Star.Mass >= 100){SceneManager.LoadScene("HomeScreen/supernova");}
    }
}