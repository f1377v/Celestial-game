using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopSectionScrollViewContentView : MonoBehaviour {
	private static Dictionary<Shop.Section, string> titleBySection = new Dictionary<Shop.Section, string> {
		[Shop.Section.SmallFuelBoosts] = "Tight on Funds $",
		[Shop.Section.MediumFuelBoosts] = "Living Comfortably $$",
		[Shop.Section.LargeFuelBoosts] = "BALLIN' $$$"
	};

	public GameObject shopSectionScrollViewCellTemplate;

	void Start() {
		Populate();
	}

	void Populate() {
		foreach (Shop.Section s in ShopController.GetShopSectionsByOrder()) {
			if (ShopController.IsSectionDefined(s)) {
				GameObject o = (GameObject) Instantiate(shopSectionScrollViewCellTemplate, transform);
				ShopSectionScrollViewCell c = o.GetComponent<ShopSectionScrollViewCell>();

				c.setSection(s);
				c.SetTitle(titleBySection[s]);
			}
		}
	}
}