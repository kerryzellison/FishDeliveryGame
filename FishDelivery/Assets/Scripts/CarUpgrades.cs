using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarUpgrades : MonoBehaviour
{
    // Access to other script on the player object
    ResourceSystem resources;
    /////////////////

    public GameObject upgradeMenu;

    [System.Serializable]
    public class UpgradeItem
    {
        public bool purchased = false;
        public int price;
    }
    public UpgradeItem[] upgrades;

    private void Start()
    {
        resources = GetComponent<ResourceSystem>();
    }

    public void purchaseUpgrade(int upgradeNum)
    {
        if (resources.GetMoney() >= upgrades[upgradeNum].price)
        {
            upgrades[upgradeNum].purchased = true;
            resources.SetMoney(resources.GetMoney() - upgrades[upgradeNum].price); // Subtract price from player's money

            if (upgradeNum == 0) // Fish-tank Lid
            {

            }
            else if (upgradeNum == 1) // Glider
            {

            }
            else if (upgradeNum == 2) // Booster Rockets
            {

            }
            else if (upgradeNum == 3) // Nitro capacity increase
            {

            }
            else if (upgradeNum == 4) // Fish-tank size
            {

            }
            else if (upgradeNum == 5) //
            {

            }
            else if (upgradeNum == 6) //
            {

            }
            else if (upgradeNum == 7) //
            {

            }
            else if (upgradeNum == 8) //
            {

            }
            else if (upgradeNum == 9) //
            {

            }
            else
                Debug.Log("Unknown upgrade purchased, bigger than max: " + upgradeNum);
        }
        else
        {
            Debug.Log("Player has insufficient currency!");
        }
    }

    public void UpgradeMenuOpened(bool opened) 
    {
        if (opened)
        {
            upgradeMenu.SetActive(true);
        }
        else
        {
            upgradeMenu.SetActive(false);
        }
    }
}
