using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class UpgradeMenu : MonoBehaviour
{
    public UpgradeData upgradeData;
    private const int MAX_LEVEL = 1;

    public List<UpgradeForm> motorLevels = new List<UpgradeForm>();
    public List<UpgradeForm> wheelsLevels = new List<UpgradeForm>();
    public List<UpgradeForm> batteryLevels = new List<UpgradeForm>();
    public List<UpgradeForm> currencyLevels = new List<UpgradeForm>();

    public int boostCost;
    public int solarPanelCost;

    public PhysicsMaterial2D tires;

    public void MotorUpgrade() {
        UpgradeForm formData = motorLevels[upgradeData.motorLevel];
        if(upgradeData.motorLevel < MAX_LEVEL &&
            upgradeData.moneyAmount >= formData.cost)
		{
            IncreaseValue(upgradeData.moneyAmount, -formData.cost);
            // Set motor to formData.value
            Save("Motor", formData.value);
            upgradeData.motorLevel++;
            
        }
    }
    
    public void WheelsUpgrade() {
        UpgradeForm formData = wheelsLevels[upgradeData.gripLevel];
        if(upgradeData.gripLevel < MAX_LEVEL &&
			upgradeData.moneyAmount >= formData.cost)
		{
			IncreaseValue(upgradeData.moneyAmount, -formData.cost);
            // Set wheels to formData.value
            tires.friction = formData.value;
            upgradeData.gripLevel++;
        }
    }

    public void BatteryUpgrade() {
        UpgradeForm formData = batteryLevels[upgradeData.batteryLevel];
        if(upgradeData.batteryLevel < MAX_LEVEL &&
			upgradeData.moneyAmount >= formData.cost)
		{
			IncreaseValue(upgradeData.moneyAmount, -formData.cost);
			// Set battery to formData.value
			Save("Battery", formData.value);
            upgradeData.batteryLevel++;
        }
    }

    public void CurrencyUpgrade() {
        UpgradeForm formData = currencyLevels[upgradeData.currencyLevel];

        if(upgradeData.currencyLevel < MAX_LEVEL && upgradeData.moneyAmount >= formData.cost)
		{
			IncreaseValue(upgradeData.moneyAmount, -formData.cost);
			// Set currency to formData.value
			Save("Currency", formData.value);
            upgradeData.currencyLevel++;
        }
    }

    public void FireworkUpgrade() {
        if(!upgradeData.boostLevel &&
            upgradeData.moneyAmount >= boostCost) {
			IncreaseValue(upgradeData.moneyAmount, boostCost);
			// Set Boost to true
			Save("Boost", 1);
            upgradeData.boostLevel = true;
        }
    }

    public void SolarPanelUpgrade() {
        if(!upgradeData.solarPanelsLevel &&
			upgradeData.moneyAmount >= solarPanelCost) {
			IncreaseValue(upgradeData.moneyAmount, solarPanelCost);
			// Set Solar Panel to true
			Save("SolarPanel", 1);
            upgradeData.solarPanelsLevel = true;
        }
    }

    public void Reset()
    {
        upgradeData.motorLevel = 0;
        upgradeData.gripLevel = 0;
        upgradeData.batteryLevel = 0;
        upgradeData.boostLevel = false;
        upgradeData.currencyLevel = 0;
        upgradeData.solarPanelsLevel = false;
		upgradeData.moneyAmount = 0;
        tires.friction = 1;
    }

    public void Play(string scene) {
        SceneManager.LoadScene(scene);
    }

    private void Save(string name, int value) {
        PlayerPrefs.SetInt(name, value);
    }

	public void IncreaseValue(int value, int amount)
	{
		value += amount;
	}
}

