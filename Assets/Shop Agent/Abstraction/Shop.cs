using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop {
    //Enums are defined solely for the porpuse of identification, makes the code easier to understand.
    public enum Section {
        SmallFuelBoosts,
        MediumFuelBoosts,
        LargeFuelBoosts
    }

    //Adding all the enums to an array to give them order by indexing them.
    public static Section[] sectionsByOrder = new Section[] {
		Section.SmallFuelBoosts,
		Section.MediumFuelBoosts,
        Section.LargeFuelBoosts,
	};

    //Creating a dictionary to associate shop items to a section.
    public static Dictionary<Shop.Section, ShopItem[]> shopItemsByOrderBySection = new Dictionary<Shop.Section, ShopItem[]>();

    //associating shop items to a section by adding them to the dictionary(How this will affect the order in the UI can be seen in the ShopItemScrollViewContentView).
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
