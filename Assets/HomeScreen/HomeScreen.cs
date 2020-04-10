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
        
        // PlayerPrefs.DeleteAll();
        // if the mass is between 0 and 20 activate the dying star and deactivate the previous star (downgrade)
        if ( 0 < mass && mass < 20 ) {startStar.SetActive(false);dyingStar.SetActive(true);}

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
	}

    void Update() {

        fuel = Star.Fuel;
        mass = Star.Mass;
        currency = Star.Currency;
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

        if ( Input.GetKeyDown ("0") ) {Star.Mass = 0;}
        if ( Input.GetKeyDown ("1") ) {Star.Mass = 10; Debug.Log("1");}
        if ( Input.GetKeyDown ("2") ) {Star.Mass = 30;}
        if ( Input.GetKeyDown ("3") ) {Star.Mass = 50; Debug.Log("3");}
        if ( Input.GetKeyDown ("4") ) {Star.Mass = 70;}
        if ( Input.GetKeyDown ("5") ) {Star.Mass = 90;}

        if ( Input.GetKeyDown ("h") ) {Star.Fuel = 40;}
        if ( Input.GetKeyDown ("f") ) {Star.Fuel = 15;}
        if ( Input.GetKeyDown ("z") ) {Star.Fuel = 0;}


        //if the mass is zero load the gameover scene
        if ( mass == 0 ){SceneManager.LoadScene("HomeScreen/gameover");}

        // if the mass is between 0 and 20 activate the dying star and deactivate the previous star (downgrade)
        if ( 0 < mass && mass < 20 ) {startStar.SetActive(false);dyingStar.SetActive(true);}

        // if the mass is between 20 and 40 activate the dying star and deactivate the previous star (downgrade and upgarde)
        else if ( 20 <= mass && mass < 40) {
            dyingStar.SetActive(false);
            startStar.SetActive(true);
            redStar.SetActive(false);
        }

        else if( 40 <= mass && mass < 60 ){
            startStar.SetActive(false);
            redStar.SetActive(true);
            purpleStar.SetActive(false);
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

    public void ShowStats(){
        SceneManager.LoadScene("");
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
	
	// 	updateDevice();
	// }
	
	void updateDevice(){
	}
	
}