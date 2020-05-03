using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class PreviousScreenIcon : MonoBehaviour, IPointerClickHandler {
    public void OnPointerClick(PointerEventData eventData) {
        FindObjectOfType<AudioManager>().Play("Back");  
        ShopController.TerminateShop();
    }
}
