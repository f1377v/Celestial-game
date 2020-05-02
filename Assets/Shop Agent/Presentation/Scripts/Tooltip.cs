using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour {

    private static Tooltip instance;

    private Text tooltipText;

    private Image tooltipBackgroundImage;
    private RectTransform tooltipBackgroundRectTransform;




    private void Awake() {
        instance = this;
        // finding the TooltipText child within the Tooltip object(no need for specifying the parent object since the script is attached to it)
        tooltipText = transform.Find("TooltipText").GetComponent<Text>();

        tooltipBackgroundImage = transform.Find("TooltipBackground").GetComponent<Image>();
        tooltipBackgroundRectTransform = transform.Find("TooltipBackground").GetComponent<RectTransform>();
        Tooltip.HideTooltip();
    }

    private void Update() {
        Vector2 localPoint;

        //retrieving the mouse location on the screen using the function below
        RectTransformUtility.ScreenPointToLocalPointInRectangle(transform.parent.GetComponent<RectTransform>(), Input.mousePosition, null, out localPoint);

        localPoint.x += 5;
        localPoint.y += -5;
        transform.localPosition = localPoint;
    }

    private void _ShowTooltip(string tip, bool isWarning) {
        if (tip != null && tip != "") {
            //Scaling the game object from (0, 0, 0) which basically means hidden to (1, 1, 0).
            gameObject.transform.localScale = new Vector3(1, 1, 0);
            
            //Making the gameObject the last in the hierarchy, so that it would appear the first on the screen. 
            transform.SetAsLastSibling();
            if (isWarning) {
                tooltipText.color = Color.white;
                tooltipBackgroundImage.color = Color.red;
                tooltipText.text = tip;
            }
            else if (tip.Substring(0, 7) == "Success") {
                tooltipText.color = Color.white;
                tooltipBackgroundImage.color = Color.green;
                // substring(8) to get rid of the success in the beginning of the sentence
                tooltipText.text = tip.Substring(8);
            }
            else{
                tooltipText.color = Color.white;
                tooltipBackgroundImage.color = Color.black;
                tooltipText.text = tip;              
            }
            float textPaddingSize = 4f;

            Vector2 newSize = new Vector2(tooltipText.preferredWidth + 2*textPaddingSize, tooltipText.preferredHeight + 2*textPaddingSize);
            tooltipBackgroundRectTransform.sizeDelta = newSize;
        }
    }


    private void _HideTooltip() {
        gameObject.transform.localScale = new Vector3(0, 0, 0);
    }


    public static void ShowTooltip(string tip, bool isRed) {
        instance._ShowTooltip(tip, isRed);
    }

    public static void HideTooltip() {
        instance._HideTooltip();
    }

}
