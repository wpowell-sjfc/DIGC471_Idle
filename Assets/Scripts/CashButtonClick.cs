using UnityEngine;

public class CashButtonClick : MonoBehaviour
{
    public void ClickTheButton()
    {
        if (GlobalLemonade.LemonadeCount <= 0)
        {
            Debug.Log("I cannot sell what I don't have.");
        }
        else
        {
            GlobalLemonade.LemonadeCount -= 1;
            GlobalCash.CashCount += 1;
        }
    }
}
