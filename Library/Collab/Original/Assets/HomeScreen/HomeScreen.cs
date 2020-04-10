using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;					
public class HomeScreen : MonoBehaviour
{   
    
	private int fuel;
    private int mass; 
    private int currency;
    private float timer = 0.0f;

    public GameObject hungerText;
    public GameObject currencyText;
    public GameObject massText;
    public GameObject dyingStar;
    public GameObject startStar;
    public GameObject redStar;
    public GameObject purpleStar;
    public GameObject whiteStar;
	
	void Start(){
        //Setting the right image based on mass
	}

    void Update() {

        fuel = Star.Fuel;
        mass = Star.Mass;
        brights = Star.Currency;
        hungerText.GetComponent<Text> ().text = "" + fuel;
        currencyText.GetComponent<Text> ().text = " " + currency;
        massText.GetComponent<Text> ().text = " " + mass;

        //Changing the mass based on fuel
        timer = timer + Time.deltaTime;
        if (timer > 5.0f){
            if (25 < fuel && fuel < 50){
                mass = mass - 1;
            }
            
            else if (0 < fuel && fuel < 25){
                mass = mass - 2;
            }

            else if (fuel == 0){
                mass = mass - 3;
            }

            timer = timer - 5.0f;
        };

        // Setting the mass of the star to the new value
        Star.Mass = mass;

        //if the mass is zero load the gameover scene
        if ( mass == 0 ){SceneManager.LoadScene("HomeScreen/gameover");}

        // if the mass is between 0 and 20 activate the dying star and deactivate the previous star (downgrade)
        if ( Input.GetKeyDown ("i") ) {startStar.SetActive(false);dyingStar.SetActive(true);}

        // if the mass is between 0 and 20 activate the dying star and deactivate the previous star (downgrade and upgarde)
        else if ( 20 <= mass && mass < 40) {
            dyingStar.SetActive(false);
            startStar.SetActive(true);
            redStar.SetActive(false);
        }

        else if( 40 <= mass && mass < 60 ){
            dyingStar.SetActive(false);
            startStar.SetActive(true);
            redStar.SetActive(false);
        }

        else if( 60 <= mass && mass < 80){
            redStar.SetActive(false);
            purpleStar.SetActive(true);
            whiteStar.SetActive(false);
        }

        else if ( 80 <= mass && mass < 100){
            purpleStar.SetActive(false);
            whiteStar.SetActive(true);
        }

        else if (mass == 100){SceneManager.LoadScene("HomeScreen/supernova");}
    }

    public void PlayGame(){
        SceneManager.LoadScene("");
    }

    public void ShowStats(){
        SceneManager.LoadScene("");
    }

    public void Show_Leaderboard(){
        SceneManager.LoadScene("Leaderboard/Leaderboard");
    }

    public void ShowShop(){
        SceneManager.LoadScene("Shop Agent/View/Shop");
    }
	
	// void updateHunger(){
	// 	if(!PlayerPrefs.HasKey("_hunger")) {
	// 		_hunger = 0;
	// 		PlayerPrefs.SetInt("_hunger", _hunger);
	// 	} else {
	// 		_hunger = PlayerPrefs.GetInt("_hunger");
	// 	}
	// 	updateDevice();
	// }
	
	void updateDevice(){
	}
	
}