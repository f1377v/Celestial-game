using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PreviousScene : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData){
        FindObjectOfType<AudioManager>().Play("Back");
        SceneManager.LoadScene("Homescreen/Homescreen");
    }    
}
