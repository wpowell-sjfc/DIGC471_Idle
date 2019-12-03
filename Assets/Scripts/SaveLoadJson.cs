using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class SaveLoadJson : MonoBehaviour
{
    private static string jsonSavePath;

    public static void LoadData()
    {
        LemonSave lemonSave = JsonUtility.FromJson<LemonSave>(File.ReadAllText(jsonSavePath));

        GlobalLemonade.LemonadeCount = lemonSave.serializedLemonade;
        GlobalCash.CashCount = lemonSave.serializedPounds;

        //Debug.Log((TimeSpan)(DateTime.UtcNow - 
        //DateTime.Parse(lemonSave.serializedDateTime)));
        if (lemonSave.serializedDateTime != null)
        {
            TimeSpan dTime = DateTime.UtcNow - DateTime.Parse(lemonSave.serializedDateTime);
            GlobalLemonade.LemonadeCount += (int)(dTime.TotalSeconds);
            Debug.Log("Generated " + (int)(dTime.TotalSeconds) + " cups of lemonade!");
        }

        //For testing purposes
        Debug.Log("Lemonade: " + GlobalLemonade.LemonadeCount);
        Debug.Log("Pounds: " + GlobalCash.CashCount);
        LemonSave.loaded = true;
    }

    public static void SaveData()
    {
        //Reference
        LemonSave lemonSave = new LemonSave();

        //Lemonade
        lemonSave.serializedLemonade = GlobalLemonade.LemonadeCount;
        LemonSave.lemonade = lemonSave.serializedLemonade;

        //Pounds
        lemonSave.serializedPounds = GlobalCash.CashCount;
        LemonSave.pounds = lemonSave.serializedPounds;

        //Time
        lemonSave.serializedDateTime = DateTime.UtcNow.
            ToString("HH:mm:ss dd MMMM, yyyy");

        Debug.Log("Saving Lemonade Value: " + GlobalLemonade.LemonadeCount);
        Debug.Log("Saving Cash Value: " + GlobalCash.CashCount);

        string jsonData = JsonUtility.ToJson(lemonSave, true);
        File.WriteAllText(jsonSavePath, jsonData);
        Debug.Log(jsonData);
    }

    void Start()
    {
        jsonSavePath = Application.persistentDataPath + "/lemonadestand.json";
        Debug.Log(jsonSavePath);
        if (File.Exists(jsonSavePath))
        {
            SaveLoadJson.LoadData();
        }
        StartCoroutine(AutoSave());
    }

    IEnumerator AutoSave()
    {
        yield return new WaitForSeconds(30);
        SaveLoadJson.SaveData();
        StartCoroutine(AutoSave());
    }
}

public class LemonSave
{
    public int serializedLemonade;
    public int serializedPounds;
    public static int lemonade;
    public static int pounds;
    public static bool loaded = false;
    public string serializedDateTime;
}
