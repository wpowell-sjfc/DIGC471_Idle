using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoGenerate : MonoBehaviour
{

    public bool CreatingLemonade = false;
    public static int LemonadeIncrease = 1;
    public int InternalIncrease;

    void Update()
    {
        InternalIncrease = LemonadeIncrease;
        if (CreatingLemonade == false)
        {
            CreatingLemonade = true;
            StartCoroutine(SqueezeLemonade());
        }
    }

    IEnumerator SqueezeLemonade()
    {
        GlobalLemonade.LemonadeCount += InternalIncrease;
        yield return new WaitForSeconds(1);
        CreatingLemonade = false;
    }
}

