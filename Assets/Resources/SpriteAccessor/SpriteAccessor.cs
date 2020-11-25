using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAccessor: MonoBehaviour {

    private static SpriteAccessor singletonInstance;

    public static SpriteAccessor instance {
        get {
            if (singletonInstance == null) {
                singletonInstance = (Instantiate(Resources.Load("SpriteAccessor/Sprites")) as GameObject).GetComponent<SpriteAccessor>();
            }
            return singletonInstance;
        }
    }

    // Items
    public Sprite undefinedItem;
    public Sprite HydrogenAtoms;
    public Sprite SmallStar;
    public Sprite PersonYouHate;
    public Sprite SmallRock;
    public Sprite LargeRock;
    public Sprite MediumRock;

}
