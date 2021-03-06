﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public struct ShopItem  {
    public static ShopItem HydrogenAtoms = new ShopItem(
        "fuel",
        "Hydrogen Atoms",
        SpriteAccessor.instance.HydrogenAtoms,
        "+3 fuel\n\nStars undergo nuclear reactions which convert \n hydrogen nuclei to helium nuclei, releasing excess energy. In other words, make atoms go boom.",
        100,
        () => {
            Star.Fuel += 3;
        }
    );

    public static ShopItem SmallRock = new ShopItem(
        "mass",
        "Small Rock",
        SpriteAccessor.instance.SmallRock,
        "+3 mass\n\nA star's third favourite snack.",
        300,
        () => {
            Star.Mass += 3;
        }
    );

    public static ShopItem SmallStar = new ShopItem(
        "fuel",
        "Small Star",
        SpriteAccessor.instance.SmallStar,
        "+10 fuel\n\n Make your star consume a smaller star! It's not cannibalism\nbecause these stars aren't ACTUALLY living creatures... right?",
        500,
        () => {
            Star.Fuel += 10;
        }
    );

    public static ShopItem MediumRock = new ShopItem(
        "mass",
        "Medium Rock",
        SpriteAccessor.instance.MediumRock,
        "+7 mass\n\nA star's second favourite snack.",
        650,
        () => {
            Star.Mass += 7;
        }
    );

    public static ShopItem PersonYouHate = new ShopItem(
        "mass",
        "A Person You Hate",
        SpriteAccessor.instance.PersonYouHate,
        "+100 Fuel\n\nSend your enemy to your star! Nothing is better fuel than hatred.",
        1_000,
        () => {
            Star.Fuel += 100;
        }
    );

    public static ShopItem LargeRock = new ShopItem(
        "mass",
        "Large Rock",
        SpriteAccessor.instance.LargeRock,
        "+15 mass\n\nA star's favourite snack... wait a minute",
        700,
        () => {
            Star.Mass += 15;
        }
    );

// private string name;  
// public string Name  
// {  
//    get { return this.name; }  
//    set { this.name = value; }  
// } 
// The above lines of code is equivalent to the one line of code below 
    public string type {
        get;
    }
    public string name {
        get;
    }

    public Sprite icon {
        get;
    }

    public string description {
        get;
    }

    public int marketValue {
        get;
    }

    public Action action {
        get;
    }


    public ShopItem(string type, string name, Sprite icon, string description, int marketValue, Action action) {
        this.type = type;
        this.name = name;
        this.icon = icon;
        this.description = description;
        this.marketValue = marketValue;
        this.action = action;
    }
}
