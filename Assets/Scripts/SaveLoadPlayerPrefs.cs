using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class SaveLoadPlayerPrefs : MonoBehaviour
{
    public static void LoadData()
    {
        int savedLemons = PlayerPrefs.GetInt("SavedLemons");
        GlobalLemonade.LemonadeCount = savedLemons;
        int savedCash = PlayerPrefs.GetInt("SavedCash");
        GlobalCash.CashCount = savedCash;

        //For testing purposes
        Debug.Log("Lemonade: " + GlobalLemonade.LemonadeCount);
        Debug.Log("Pounds: " + GlobalCash.CashCount);
    }

    public static void SaveData()
    {
        PlayerPrefs.SetInt("SavedLemons", GlobalLemonade.LemonadeCount);
        PlayerPrefs.SetInt("SavedCash", GlobalCash.CashCount);

        Debug.Log("Saving Lemonade Value: " + GlobalLemonade.LemonadeCount);
        Debug.Log("Saving Cash Value: " + GlobalCash.CashCount);
    }

    void Start()
    {
        SaveLoadPlayerPrefs.LoadData();
    }
}