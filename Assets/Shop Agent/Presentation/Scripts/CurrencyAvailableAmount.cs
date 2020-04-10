using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CurrencyAvailableAmount: MonoBehaviour {
    void Update() {
        gameObject.GetComponent<TextMeshProUGUI>().text = ShopController.GetStarCurrency().ToString("N0");
    }
}
