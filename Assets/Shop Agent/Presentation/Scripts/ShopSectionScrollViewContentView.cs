using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This script is not attached to any object
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
		// Creating multiple instances of shopSectionScrollViewCellTemplate prefab which automatically creates multiple instances of the class that lies within it.
		// also setting the section field and the title for each instance
		foreach (Shop.Section s in ShopController.GetShopSectionsByOrder()) {

			//Cheking if the section is defined, which means checking that enough lines from the shop script has been executed 
			if (ShopController.IsSectionDefined(s)) { 
				GameObject o = (GameObject) Instantiate(shopSectionScrollViewCellTemplate, transform);
				ShopSectionScrollViewCell c = o.GetComponent<ShopSectionScrollViewCell>();

				c.setSection(s);
				c.SetTitle(titleBySection[s]);
			}
		}
	}
}