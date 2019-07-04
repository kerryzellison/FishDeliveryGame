using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceSystem : MonoBehaviour
{
    private int xpInt = 0;
    private readonly string xpPath = "xp1";
    private int moneyInt = 0;
    private readonly string moneyPath = "money1";

    void Start()
    {
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
            Debug.Log("Player has no XP yet");
            xpInt = 0;
        }

    }

    public void AddMoney(int amount)
    {
        amount = PlayerPrefs.GetInt(moneyPath) + amount;
        PlayerPrefs.SetInt(moneyPath, amount);
        Debug.Log("Money now: " + amount);
    }

    public void SetMoney(int amount)
    {
        PlayerPrefs.SetInt(moneyPath, amount);
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
        Debug.Log("XP set to " + amount);
    }

    public void SetXP(int amount)
    {
        PlayerPrefs.SetInt(xpPath, amount);
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

}