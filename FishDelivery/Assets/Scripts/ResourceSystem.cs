using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceSystem : MonoBehaviour
{
    private int xpInt = 0;
    private readonly string xpPath = "xp1";
    private int moneyInt = 0;
    private readonly string moneyPath = "money1";

    private UI uiScript;

    // UI counters for displaying resources
    // public Text moneyCounterText;
    // public Text xpCounterText;

    void Start()
    {
        uiScript = GetComponent<UI>();

        uiScript.moneyText1.text = GetMoney().ToString() + "¥";
        uiScript.moneyText2.text = GetMoney().ToString() + "¥";

        /* if (moneyCounterText != null)
        {
            // Set UI counters:
            moneyCounterText.text = GetMoney().ToString() + "¥";
            // xpCounterText.text = "XP: " + GetXP().ToString();
        }
        else
        {
            Debug.Log("Resource System Error! - Please attach Text objects in inspector!");
        } */


        if (PlayerPrefs.GetInt(moneyPath) != 0)
        {
            moneyInt = PlayerPrefs.GetInt(moneyPath);
            Debug.Log("Current money balance: " + PlayerPrefs.GetInt(moneyPath));
        }
        else
        {
            Debug.Log("Player has no money");
            moneyInt = 0;
        }

        if (PlayerPrefs.GetInt(xpPath) != 0)
        {
            xpInt = PlayerPrefs.GetInt(xpPath);
            Debug.Log("Current XP: " + PlayerPrefs.GetInt(xpPath));
        }
        else
        {
            // Debug.Log("Player has no XP yet");
            xpInt = 0;
        }

    }

    public void AddMoney(int amount)
    {
        amount = PlayerPrefs.GetInt(moneyPath) + amount;

        if (amount >= 0)
        {
            PlayerPrefs.SetInt(moneyPath, amount);
            uiScript.moneyText1.text = amount + "¥";
            uiScript.moneyText2.text = amount + "¥";
            Debug.Log("Money now: " + amount);
        } else
        {
            Debug.Log("Insufficient funds - Cannot be less than 0!");
        }

    }

    public void SetMoney(int amount)
    {
        if (amount >= 0)
        {
            PlayerPrefs.SetInt(moneyPath, amount);
            uiScript.moneyText1.text = amount + "¥";
            uiScript.moneyText2.text = amount + "¥";
        } else
        {
            Debug.Log("Failed to set funds - most be more than 0!");
        }

    }

    public int GetMoney()
    {
        moneyInt = PlayerPrefs.GetInt(moneyPath);
        return moneyInt;
    }

    public void AddXP(int amount)
    {
        amount = PlayerPrefs.GetInt(xpPath) + amount;
        PlayerPrefs.SetInt(xpPath, amount);
        // xpCounterText.text = "XP: " + amount;
        Debug.Log("XP set to " + amount);
    }

    public void SetXP(int amount)
    {
        PlayerPrefs.SetInt(xpPath, amount);
        // xpCounterText.text = "XP: " + amount;
    }

    public int GetXP()
    {
        xpInt = PlayerPrefs.GetInt(xpPath);
        return xpInt;
    }

    public string GetMoneyPath()
    {
        return moneyPath;
    }

    public string GetXPPath()
    {
        return xpPath;
    }

    public void ResetAll()
    {
        PlayerPrefs.SetInt(moneyPath, 0);
        PlayerPrefs.SetInt(xpPath, 0);
    }

}