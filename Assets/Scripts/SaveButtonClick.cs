using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveButtonClick : MonoBehaviour
{
    public void ClickTheButton()
    {
        SaveLoadJson.SaveData();
    }
}
