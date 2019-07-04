using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public ResourceSystem ResourceSystem;
    private string moneyPath; private string xpPath;

    public Text moneyCounterText;
    public Text xpCounterText;

    void Start()
    {
        if (ResourceSystem != null)
        {
            moneyPath = ResourceSystem.GetMoneyPath();
            xpPath = ResourceSystem.GetXPPath();

            // Set UI counters:
            moneyCounterText.text = "Balance: " + ResourceSystem.GetMoney().ToString() + "¥";
            xpCounterText.text = "XP: " + ResourceSystem.GetXP().ToString();
        } else
        {
            Debug.Log("Error! - Please attach ResourceSystem script in inspector!");
        }

    }

    public void UpdateUICounters()
    {
        moneyCounterText.text = "Balance: " + ResourceSystem.GetMoney().ToString() + "¥";
        xpCounterText.text = "XP: " + ResourceSystem.GetXP().ToString();
    }

}
