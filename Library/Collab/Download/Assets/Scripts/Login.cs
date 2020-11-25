using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text.RegularExpressions;
using UnityEngine.UI;

public class Login : MonoBehaviour{
    public GameObject username;
    public GameObject password;
    private string Username;
    private string Password;
    private String[] Lines;
    
    public void LoginButton(){
        bool UN = false;
        bool PW = false;
        if(Username != ""){
            //change to checking if login info exists in DB
            if(System.IO.File.Exists(@"C:\Users\lchri\Documents\Unity\TestFolder\"+Username+".txt")){
                UN = true;
                //change to getting password from database
                Lines = System.IO.File.ReadAllLines(@"C:\Users\lchri\Documents\Unity\TestFolder\"+Username+".txt");
            }
            else{
                Debug.LogWarning("Username taken");
            }
        }
        else{
            Debug.LogWarning("Username field empty");
        }
        if(Password != ""){
            //may remove if stmt as not dependant on existence of file
            if (!System.IO.File.Exists(@"C:\Users\lchri\Documents\Unity\TestFolder\" + Username + ".txt"))
            {
                Debug.LogWarning("Password incorrect");
            }
            else
            {
                if (String.Equals(Password, Lines[2]))
                {
                    PW = true;
                }
                else
                {
                    Debug.LogWarning("Password incorrect");
                }
            }
        }
        else{
            Debug.LogWarning("Password field empty");
        }

        if(UN == true && PW == true){
            username.GetComponent<InputField>().text = "";
            password.GetComponent<InputField>().text = "";
            //go to main game screen
            print("Login Successful");
            //Application.LoadLevel(); use to load the next scene
        }
    }

    // Update is called once per frame
    void Update(){
        if (Input.GetKeyDown(KeyCode.Tab)){
            if (username.GetComponent<InputField>().isFocused){
                password.GetComponent<InputField>().Select();
            }
        }
        if(Input.GetKeyDown(KeyCode.Return)){
            if(Password != ""  && Username != ""){
                LoginButton();
            }
        }
        Username = username.GetComponent<InputField>().text;
        Password = password.GetComponent<InputField>().text;
    }
}
