using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loginInfo 
{
    public static string Username;
    public static string Password;

    public string getUsername(){
        return Login.Username;
    }

    public string getPassword(){
        return PlayerPrefs.GetString(Login.Username);
    }
}
