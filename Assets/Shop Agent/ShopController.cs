using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopController {
    public static int GetStarCurrency() {
        return Star.Currency;
    }

    public static void TerminateShop() {
        SceneManager.LoadScene("Homescreen/Homescreen");
    }

    public static ShopItem[] GetShopItemsByOrderBySection(Shop.Section s) {
        return Shop.shopItemsByOrderBySection[s];
    }

    public static bool IsSectionDefined(Shop.Section s) {
        return canGetShopItemByOrderForSection(s) && ShopController.GetShopItemsByOrderBySection(s) != null && 0 < ShopController.GetShopItemsByOrderBySection(s).Length;
    }

    private static bool canGetShopItemByOrderForSection(Shop.Section s) {
        return Shop.shopItemsByOrderBySection.ContainsKey(s);
    }

    public static Shop.Section[] GetShopSectionsByOrder() {
        return Shop.sectionsByOrder;
    }

}
