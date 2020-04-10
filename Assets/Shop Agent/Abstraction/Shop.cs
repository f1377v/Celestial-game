using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop {
    public enum Section {
        SmallFuelBoosts,
        MediumFuelBoosts,
        LargeFuelBoosts
    }

    public static Section[] sectionsByOrder = new Section[] {
		Section.SmallFuelBoosts,
		Section.MediumFuelBoosts,
        Section.LargeFuelBoosts,
	};

    public static Dictionary<Shop.Section, ShopItem[]> shopItemsByOrderBySection = new Dictionary<Shop.Section, ShopItem[]>();

    static Shop() {
        shopItemsByOrderBySection.Add(
            Section.SmallFuelBoosts,
            new ShopItem[] {
                ShopItem.HydrogenAtoms, ShopItem.SmallRock
            }
        );

        shopItemsByOrderBySection.Add(
            Section.MediumFuelBoosts,
            new ShopItem[] {
                ShopItem.SmallStar, ShopItem.MediumRock
            }
        );

        shopItemsByOrderBySection.Add(
            Section.LargeFuelBoosts,
            new ShopItem[] {
                ShopItem.PersonYouHate, ShopItem.LargeRock
            }
        );
    }
}
