using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveLoadJson : MonoBehaviour
{
    private static string jsonSavePath;

    public static void LoadData()
    {
        LemonSave lemonSave = JsonUtility.FromJson<LemonSave>(File.ReadAllText(jsonSavePath));

        GlobalLemonade.LemonadeCount = lemonSave.serializedLemonade;
        GlobalCash.CashCount = lemonSave.serializedPounds;

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
}
