using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text.RegularExpressions;
using UnityEngine.UIElements;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour{
    public GameObject username;
    public GameObject password;
    public GameObject errMessage;
    public GameObject errText;

    private static string usernameString;
    public static string Username {
        set {
            usernameString = value;
        }
        get {
            return usernameString;
        }
    }
    private string Password;
    
    public void LoginButton(){
        bool UN = false;
        bool PW = false;
        string getPass = "";
        
        Username = username.GetComponent<InputField>().text;

        if(Username != ""){
            //change to checking if login info exists in DB
            if(PlayerPrefs.HasKey(Username)){
                UN = true; 
                getPass = PlayerPrefs.GetString(Username);
                print(getPass);
                Debug.Log(getPass);
            }
            else{
                errText.GetComponent<Text>().text  = "Username Taken" + "\n Exit by pressing space" ;
                errMessage.SetActive(true);

                if (Input.GetKeyDown(KeyCode.Space)){
                    errMessage.SetActive(false);
                }
                Debug.LogWarning("Username taken");
            }
        }
        else{
            errText.GetComponent<Text>().text  = "Username field empty" + "\n Exit by pressing space" ;
            errMessage.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Space)){
                errMessage.SetActive(false);
            }
            Debug.LogWarning("Username field empty");
        }
        if(Password != ""){
            if (String.Equals(Password, getPass)){
                PW = true;
            }
            else{
                errText.GetComponent<Text>().text  = "Password incorrect" + "\n Exit by pressing space";
                errMessage.SetActive(true);

                if (Input.GetKeyDown(KeyCode.Space)){
                    errMessage.SetActive(false);
                }
                Debug.LogWarning("Password incorrect");
            }
        }
        else{
            errText.GetComponent<Text>().text  = "Password field empty" + "\n Exit by pressing space";
                errMessage.SetActive(true);

                if (Input.GetKeyDown(KeyCode.Space)){
                    errMessage.SetActive(false);
                }
            Debug.LogWarning("Password field empty");
        }

        if(UN == true && PW == true){
            username.GetComponent<InputField>().text = "";
            password.GetComponent<InputField>().text = "";
            loadStar();
            SceneManager.LoadScene("HomeScreen/Homescreen");
        }
    }

    private void loadStar() {
        Star.Mass = PlayerPrefs.GetInt(Username + ".mass", 100);
        Star.Fuel = PlayerPrefs.GetInt(Username + ".fuel", 100);
        Star.Currency = PlayerPrefs.GetInt(Username + ".currency", 0);
    }

    // Update is called once per frame
    void Update(){
        if (Input.GetKeyDown(KeyCode.Tab)){
            if (username.GetComponent<InputField>().isFocused){
                password.GetComponent<InputField>().Select();
            }
        }
        if(Input.GetKeyDown(KeyCode.Return)){
            if(Password != ""  && Register.Username != ""){
                LoginButton();
            }
        }
        Register.Username = username.GetComponent<InputField>().text;
        Password = password.GetComponent<InputField>().text;
    }
}