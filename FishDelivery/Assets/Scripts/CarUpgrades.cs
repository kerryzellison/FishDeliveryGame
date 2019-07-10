using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarUpgrades : MonoBehaviour
{
    // Access to other script on the player object
    ResourceSystem resources;
    InputManager2 input;
    /////////////////

    public GameObject upgradeMenu;

    [System.Serializable]
    public class UpgradeItem
    {
        public bool purchased = false;
        public int price;
    }
    public UpgradeItem[] upgrades;
    [HideInInspector] public bool boosterRocketsEnabled;
    [HideInInspector] public bool airGliderEnabled;
    [HideInInspector] public bool nitroBoostersEnabled;
    [HideInInspector] public bool fishTankLidEnabled;
    [HideInInspector] public int nitroCapacity;
    [HideInInspector] public int fishTankSize;

    [SerializeField] private int maxNitroCapacity = 500;
    [SerializeField] private int maxFishTankSize = 30;

    private void Start()
    {
        resources = GetComponent<ResourceSystem>();
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

    public void purchaseUpgrade(int upgradeNum)
    {
        if (resources.GetMoney() >= upgrades[upgradeNum].price)
        {
            upgrades[upgradeNum].purchased = true;
            resources.SetMoney(resources.GetMoney() - upgrades[upgradeNum].price); // Subtract price from player's money

            if (upgradeNum == 0) // Booster Rockets
            {
                boosterRocketsEnabled = true;
                Debug.Log("Booster rockets purchased");
            }
            else if (upgradeNum == 1) // Air Glider
            {
                airGliderEnabled = true;
                Debug.Log("Air Glider purchased");
            }
            else if (upgradeNum == 2) // Nitro Boosters
            {
                nitroBoostersEnabled = true;
                nitroCapacity += 100;
                Debug.Log("Nitro Boosters purchased");
            }
            else if (upgradeNum == 3) // Fish-tank Lid
            {
                fishTankLidEnabled = true;
                Debug.Log("Fish-tank Lid purchased");
            }
            else if (upgradeNum == 4 && nitroBoostersEnabled && nitroCapacity < maxNitroCapacity) // Nitro capacity increase
            {
                nitroCapacity += 50;
                Debug.Log("Nitro Capacity increased! Capacity is now " +  nitroCapacity + "!");
            }
            else if (upgradeNum == 5 && fishTankSize < maxFishTankSize) // Fish-tank size
            {
                fishTankSize += 5;
                Debug.Log("Fish-tank Size increased! The tank can now hold is now " + fishTankSize + " fish!");
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

}
