using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemScrollViewContentView : MonoBehaviour {
	public GameObject shopItemScrollViewCellTemplate;
	private Shop.Section section;

	void Start() {
		GameObject parentScrollView = transform.parent.parent.parent.gameObject;
		section = parentScrollView.GetComponent<ShopSectionScrollViewCell>().getSection();
		Populate();
	}

	void Populate() {
		foreach (ShopItem s in ShopController.GetShopItemsByOrderBySection(section)) {
			GameObject o = (GameObject) Instantiate(shopItemScrollViewCellTemplate, transform);
			ShopItemScrollViewCell c = o.GetComponent<ShopItemScrollViewCell>();

			c.item = s;
			c.setItemName(s.name);
			c.setItemIcon(s.icon);
			c.setItemDescription(s.description);
			c.setItemPrice(s.marketValue.ToString());
		}
	}
}