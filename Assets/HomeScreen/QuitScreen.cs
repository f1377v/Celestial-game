using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitScreen : MonoBehaviour {
    public void QuitGame ()
    {
        Debug.Log ("QUIT!");
        Application.Quit();
    }

    public void Restart(){
        PlayerPrefs.DeleteKey(Login.Username + ".mass");
        PlayerPrefs.DeleteKey(Login.Username + ".fuel");
        PlayerPrefs.DeleteKey(Login.Username + ".currency");
        SceneManager.LoadScene("Login/presentation/Login");
        Debug.Log("Restart");
    }  
}