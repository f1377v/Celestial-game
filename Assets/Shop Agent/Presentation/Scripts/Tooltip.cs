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
        tooltipText = transform.Find("TooltipText").GetComponent<Text>();
        tooltipBackgroundImage = transform.Find("TooltipBackground").GetComponent<Image>();
        tooltipBackgroundRectTransform = transform.Find("TooltipBackground").GetComponent<RectTransform>();
        Tooltip.HideTooltip();
    }

    private void Update() {
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(transform.parent.GetComponent<RectTransform>(), Input.mousePosition, null, out localPoint);
        localPoint.x += 5;
        localPoint.y += -5;
        transform.localPosition = localPoint;
    }

    private void _ShowTooltip(string tip, bool isWarning) {
        if (tip != null && tip != "") {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
            transform.SetAsLastSibling();

            tooltipText.text = tip;
            if (isWarning) {
                tooltipText.color = Color.white;
                tooltipBackgroundImage.color = Color.red;
            } else {
                tooltipText.color = Color.white;
                tooltipBackgroundImage.color = Color.black;
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
