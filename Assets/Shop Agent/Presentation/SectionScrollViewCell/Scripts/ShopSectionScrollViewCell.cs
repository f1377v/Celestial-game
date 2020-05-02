using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopSectionScrollViewCell : MonoBehaviour {
    private Shop.Section s;

    public void setSection(Shop.Section s) {
        this.s = s;
    }

    public Shop.Section getSection() {
        return s;
    }

    public void SetTitle(string s) {
        transform.Find("SectionTitle").GetComponent<TextMeshProUGUI>().SetText(s);
    }
}
