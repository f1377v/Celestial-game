using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This script is attached to the content object in ShopSectionScrollViewCell prefab
public class ShopItemScrollViewContentView : MonoBehaviour {
	public GameObject shopItemScrollViewCellTemplate;
	private Shop.Section section;

	void Start() {
		// getting the parent which is the ShopItemScrollViewContentViewTemplate
		GameObject parentScrollView = transform.parent.parent.parent.gameObject;

		// Accessing the shop.section of the current instance which is set in ShopSectionScrollViewContentView.cs before.
		// Since the Section must be instantiated for the content object to be instantiated, therefore the start() of this script will
		// never run before the ShopSectionScrollViewContentView.cs start().
		section = parentScrollView.GetComponent<ShopSectionScrollViewCell>().getSection();
		Populate();
	}

	void Populate() {
		// fetching items from the dictionary created in Shop.cs through the controller
		foreach (ShopItem s in ShopController.GetShopItemsByOrderBySection(section)) {

			// Instantiating the prefab and its children which comes below the content game object
			GameObject o = (GameObject) Instantiate(shopItemScrollViewCellTemplate, transform);

			// Fetching the instance created
			ShopItemScrollViewCell c = o.GetComponent<ShopItemScrollViewCell>();

			// Accessing the children objects of the prefab and changing their value to the shopitem fields  
			c.item = s;
			c.setItemName(s.name);
			c.setItemIcon(s.icon);
			c.setItemDescription(s.description);
			c.setItemPrice(s.marketValue.ToString());
		}
	}
}