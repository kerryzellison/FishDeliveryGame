using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CarUpgrades : MonoBehaviour
{
    // Access to other script on the player object
    ResourceSystem resources;
    InputManager2 input;
    /////////////////

    [System.Serializable]
    public class UpgradeItem
    {
        public string upgradeName;
        public bool purchased = false;
        public int price;
        public string description;
        public Button btn;
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

    public int disabledAlphaValue = 100;
    public float disabledAlphaValueNormalized = 0.39f;

    private void Start()
    {
        resources = GetComponent<ResourceSystem>();
        input = GameObject.FindGameObjectWithTag("Player").GetComponent<InputManager2>();
    }

    public void purchaseUpgrade(int upgradeNum)
    {
        if (resources.GetMoney() >= upgrades[upgradeNum].price)
        {
            upgrades[upgradeNum].purchased = true;
            resources.SetMoney(resources.GetMoney() - upgrades[upgradeNum].price); // Subtract price from player's money

            if (upgradeNum == 0) // Booster Rockets
            {
                upgrades[0].purchased = true;
                boosterRocketsEnabled = true;
                DisableItem(upgrades[0]);
                Debug.Log("Booster rockets purchased");

                //PlayerPrefs.SetString(upgrades[0].purchased.ToString(),"true"); // UNTESTED
            }
            else if (upgradeNum == 1) // Nitro Boosters
            {
                upgrades[1].purchased = true;
                nitroBoostersEnabled = true;
                nitroCapacity += 100;
                DisableItem(upgrades[1]);
                Debug.Log("Nitro Boosters purchased");
            }
            else if (upgradeNum == 2 && fishTankSize < maxFishTankSize) // Fish-tank size
            {
                upgrades[2].purchased = true;
                fishTankSize += 5;
                Debug.Log("Fish-tank Size increased! The tank can now hold is now " + fishTankSize + " fish!");
            }
            else if (upgradeNum == 3 && nitroBoostersEnabled && nitroCapacity < maxNitroCapacity) // Nitro capacity increase
            {
                upgrades[3].purchased = true;
                nitroCapacity += 50;
                Debug.Log("Nitro Capacity increased! Capacity is now " + nitroCapacity + "!");
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

    public void UpdateMenuText()
    {
        foreach (UpgradeItem item in upgrades)
        {
            ChangeChildText(item.btn.gameObject, "Title", item.upgradeName);
            ChangeChildText(item.btn.gameObject, "Price", item.price.ToString() + " ¥");
            ChangeChildText(item.btn.gameObject, "Description", item.description);
            if (item.purchased)
            {
                DisableItem(item);
            }
        }
    }

    public void ChangeChildText(GameObject parent, string childName, string input)
    {
        TextMeshProUGUI text = GameObject.Find(parent.name + "/" + childName).GetComponent<TextMeshProUGUI>();
        text.SetText(input);
    }
    
    private void DisableItem(UpgradeItem item)
    {
        item.btn.interactable = false;
        item.btn.image.color = new Color(item.btn.image.color.r, item.btn.image.color.g, item.btn.image.color.b, disabledAlphaValue);
        foreach (TextMeshProUGUI text in item.btn.GetComponentsInChildren<TextMeshProUGUI>())
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, disabledAlphaValueNormalized);
        }
    }
}
