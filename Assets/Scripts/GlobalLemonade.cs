using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalLemonade : MonoBehaviour
{
    public static int LemonadeCount;
    public GameObject LemonadeDisplay;
    private int InternalLemonade;

    void Update()
    {
        InternalLemonade = LemonadeCount;
        LemonadeDisplay.GetComponent<Text>().text = 
            "Cups of Lemonade: " + InternalLemonade;
    }
}
