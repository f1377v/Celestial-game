using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemInfoIcon: MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler {

    bool shouldShowOnNextClick = false;

    public string info = "";


    public void OnPointerEnter(PointerEventData eventData) {
        Tooltip.ShowTooltip(info, false);
        shouldShowOnNextClick = false;
    }

    public void OnPointerExit(PointerEventData eventData) {
        Tooltip.HideTooltip();
    }

    public void OnPointerClick(PointerEventData eventData) {
        if (shouldShowOnNextClick) {
            Tooltip.ShowTooltip(info, false);
        } else {
            Tooltip.HideTooltip();
        }

        shouldShowOnNextClick = !shouldShowOnNextClick;
    }


}
