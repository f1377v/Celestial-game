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
    public GameObject hungerText;
    public GameObject currencyText;
    public GameObject massText;
	
	void Start(){
	}

    void Update() {
        fuel = Star.Fuel;
        mass = Star.Mass;
        brights = Star.Currency;
        hungerText.GetComponent<Text> ().text = "" + fuel;
        currencyText.GetComponent<Text> ().text = " " + currency;
        massText.GetComponent<Text> ().text = " " + mass;

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