using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;


public class Register : MonoBehaviour{
    public GameObject username;
    public GameObject email;
    public GameObject password;
    public GameObject confPassword;
    public GameObject errMessage;
    public GameObject errText;


    public static string Username;
    private string Email;
    private string Password;
    private string ConfPassword;

    private string form;
    private bool emailValid = false;
    private string[] Characters = {"a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "_", "-"};

    public void RegisterButton(){
        bool UN = false;
        bool EM = false;
        bool PW = false;
        bool CPW = false;

        if(Username != "" ){
            //replace with checking database for existence of username
            if(!PlayerPrefs.HasKey(Username)){
                UN = true;
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

        if(Email != "" ){
            EmailValidation();
            if(emailValid){
                if(Email.Contains("@")){
                    if(Email.Contains(".")){
                        EM = true;
                    }
                    else{
                        errText.GetComponent<Text>().text  = "Email is incorrect" + "\n Exit by pressing space" ;
                        errMessage.SetActive(true);

                        if (Input.GetKeyDown(KeyCode.Space)){
                            errMessage.SetActive(false);
                        }
                
                        Debug.LogWarning("Email is incorrect");
                    }
                }
                else{
                    errText.GetComponent<Text>().text  = "Email is incorrect" + "\n Exit by pressing space" ;
                    errMessage.SetActive(true);

                    if (Input.GetKeyDown(KeyCode.Space)){
                        errMessage.SetActive(false);
                    }
                    Debug.LogWarning("Email is incorrect");
                }
            }
            else{
                errText.GetComponent<Text>().text  = "Email is incorrect" + "\n Exit by pressing space" ;
                errMessage.SetActive(true);

                if (Input.GetKeyDown(KeyCode.Space)){
                    errMessage.SetActive(false);
                }

                Debug.LogWarning("Email is incorrect");
            }
        }
        else{

            errText.GetComponent<Text>().text  = "Email field empty" + "\n Exit by pressing space" ;
            errMessage.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Space)){
                errMessage.SetActive(false);
            }
            Debug.LogWarning("Email field empty");
        }

        if(Password != "" ){
            if(Password.Length > 5){
                PW = true;
            }
            else{

                errText.GetComponent<Text>().text  = "Password must be at least six characters long" + "\n Exit by pressing space" ;
                errMessage.SetActive(true);

                if (Input.GetKeyDown(KeyCode.Space)){
                    errMessage.SetActive(false);
                }
                Debug.LogWarning("Password must be at least six characters long");
            }
        }
        else{

            errText.GetComponent<Text>().text  = "Password field empty" + "\n Exit by pressing space" ;
            errMessage.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Space)){
                    errMessage.SetActive(false);
            }
            Debug.LogWarning("Password field empty");
        }

        if(ConfPassword != "" ){
            if(String.Equals(ConfPassword, Password)){
                CPW = true;
            }
            else{

                errText.GetComponent<Text>().text  = "Passwords are not the same" + "\n Exit by pressing space" ;
                errMessage.SetActive(true);

                if (Input.GetKeyDown(KeyCode.Space)){
                    errMessage.SetActive(false);
                }
                Debug.LogWarning("Passwords are not the same");
            }
        }
        else{
            errText.GetComponent<Text>().text  = "Confirm Password field empty" + "\n Exit by pressing space" ;
            errMessage.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Space)){
                    errMessage.SetActive(false);
            }
           
            Debug.LogWarning("Confirm Password field empty");
        }

        if(UN == true && EM == true && PW == true && CPW == true){
            //change this to write to db
            PlayerPrefs.SetString(Username, Password);
            PlayerPrefs.SetString(Email, Email);
            
            username.GetComponent<InputField>().text = "";
            email.GetComponent<InputField>().text = "";
            password.GetComponent<InputField>().text = "";
            confPassword.GetComponent<InputField>().text = "";
        }
    }

    // Update is called once per frame
    void Update(){
        if (Input.GetKeyDown(KeyCode.Tab)){
            if (username.GetComponent<InputField>().isFocused){
                email.GetComponent<InputField>().Select();
            }
            if (email.GetComponent<InputField>().isFocused){
                password.GetComponent<InputField>().Select();
            }
            if (password.GetComponent<InputField>().isFocused){
                confPassword.GetComponent<InputField>().Select();
            }
        }

        if(Input.GetKeyDown(KeyCode.Return)){
            if(Password != "" && Email != "" && Username != "" && ConfPassword != ""){
                RegisterButton();
            }
        }
        Username = username.GetComponent<InputField>().text;
        Email = email.GetComponent<InputField>().text;
        Password = password.GetComponent<InputField>().text;
        ConfPassword = confPassword.GetComponent<InputField>().text;
    }
    void EmailValidation(){
        bool SW = false;
        bool EW = false;
        for(int i=0; i<Characters.Length; i++){
            if(Email.StartsWith(Characters[i])){
                SW = true;
            }
            if(Email.EndsWith(Characters[i])){
                EW = true;
            }
        }
        if(SW == true && EW == true){
            emailValid = true;
        }
        else{
            emailValid = false;
        }
    }
}
