using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

//Since the class handles on click and hover events it has IPointerClickHandler, IPointerExitHandler in addition to  MonoBehaviour.
public class ShopItemScrollViewCell: MonoBehaviour, IPointerClickHandler, IPointerExitHandler {

    private ShopItem s;
    public ShopItem item {
        get {
            return s;
        }
        set {
            s = value;
        }
    }
    
// for making other UI objects than buttons clickable (make sure there is a event system on the scene to detect the clicks), the objects have a on click() function on the interface
    public void OnPointerClick(PointerEventData eventData) {
        if (s.marketValue <= Star.Currency) {
            Star.Currency -= s.marketValue;
            s.action();
            Tooltip.ShowTooltip("You purchased and used " + item.name + "!", false);
        } else {
            Tooltip.ShowTooltip("You don't have enough funds to buy this!", true);
        }
    }

    public void OnPointerExit(PointerEventData eventData) {
        Tooltip.HideTooltip();
    }

    public void setItemName(string s) {
        transform.Find("ItemName").GetComponent<TextMeshProUGUI>().SetText(s);
    }

    public void setItemIcon(Sprite s) {
        transform.Find("ItemIcon").GetComponent<Image>().sprite = s;
    }

    public void setItemDescription(string s) {
       transform.Find("ItemInfoIcon").GetComponent<ItemInfoIcon>().info = s;
    }

    public void setItemPrice(string s) {
        transform.Find("ItemCostAmount").GetComponent<TextMeshProUGUI>().SetText(s);
    }
}
