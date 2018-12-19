using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using System;

public class UpgradeMenu : MonoBehaviour
{
	public Text boostCostUpgradeAmount;
	public Text gripCostUpgradeAmount;
	public Text currencyUpgradeAmount;
	public Text batteryUpgradeAmount;
	public Text motorUpgradeAmount;
	public Image boost;
	public Image grip;
	public Image currency;
	public Image battery;
	public Image motor;
	public UpgradeData upgradeData;
    public PhysicsMaterial2D tires;
    public List<UpgradeForm> motorLevels = new List<UpgradeForm>();
    public List<UpgradeForm> wheelsLevels = new List<UpgradeForm>();
    public List<UpgradeForm> batteryLevels = new List<UpgradeForm>();
    public List<UpgradeForm> currencyLevels = new List<UpgradeForm>();
    public int boostCost;
	public Color upgradedColor;

    private const int MAX_LEVEL = 1;

	private void Start()
	{
		if (upgradeData.boostLevel)
		{
			DisableUpgrade(boost, upgradedColor, null);
		}

		if (upgradeData.gripLevel > 0)
		{
			DisableUpgrade(grip, upgradedColor, wheelsLevels[0]);
		}

		if (upgradeData.currencyLevel > 0)
		{
			DisableUpgrade(currency, upgradedColor, currencyLevels[0]);
		}

		if (upgradeData.batteryLevel > 0)
		{
			DisableUpgrade(battery, upgradedColor, batteryLevels[0]);
		}

		if (upgradeData.motorLevel > 0)
		{
			DisableUpgrade(motor, upgradedColor, motorLevels[0]);
		}
	}

	private void Update()
	{
		boostCostUpgradeAmount.text = boostCost.ToString();
		gripCostUpgradeAmount.text = wheelsLevels[0].cost.ToString();
		currencyUpgradeAmount.text = currencyLevels[0].cost.ToString();
		batteryUpgradeAmount.text = batteryLevels[0].cost.ToString();
		motorUpgradeAmount.text = motorLevels[0].cost.ToString();
	}

	public void MotorUpgrade()
	{
		if (upgradeData.motorLevel >= MAX_LEVEL) return;

		UpgradeForm formData = motorLevels[upgradeData.motorLevel];
        if(upgradeData.moneyAmount >= motorLevels[0].cost)
		{
            IncreaseValue(upgradeData, -formData.cost);
			// Set motor to formData.value
			Save("Motor", formData.value);
            upgradeData.motorLevel++;
			DisableUpgrade(motor, upgradedColor, motorLevels[0]);
		}
    }

	public void WheelsUpgrade() {
		if (upgradeData.gripLevel >= MAX_LEVEL) return;

		UpgradeForm formData = wheelsLevels[upgradeData.gripLevel];
		if	(upgradeData.moneyAmount >= wheelsLevels[0].cost)
		{
			IncreaseValue(upgradeData, -formData.cost);
            // Set wheels to formData.value
            tires.friction = formData.value;
            upgradeData.gripLevel++;
			DisableUpgrade(grip, upgradedColor, wheelsLevels[0]);
		}
    }

    public void BatteryUpgrade()
	{
		if (upgradeData.batteryLevel >= MAX_LEVEL) return;

		UpgradeForm formData = batteryLevels[upgradeData.batteryLevel];
        if(upgradeData.moneyAmount >= batteryLevels[0].cost)
		{
			IncreaseValue(upgradeData, -formData.cost);
			// Set battery to formData.value
			Save("Battery", formData.value);
            upgradeData.batteryLevel++;
			DisableUpgrade(battery, upgradedColor, batteryLevels[0]);
		}
    }

    public void CurrencyUpgrade()
	{
		if (upgradeData.currencyLevel >= MAX_LEVEL) return;

        UpgradeForm formData = currencyLevels[upgradeData.currencyLevel];
		if (upgradeData.moneyAmount >= currencyLevels[0].cost)
		{
			IncreaseValue(upgradeData, -formData.cost);
			// Set currency to formData.value
			Save("Currency", formData.value);
            upgradeData.currencyLevel++;
			DisableUpgrade(currency, upgradedColor, currencyLevels[0]);
		}
    }

    public void FireworkUpgrade() {
        if(!upgradeData.boostLevel &&
            upgradeData.moneyAmount >= boostCost) {
			IncreaseValue(upgradeData, boostCost);
			// Set Boost to true
			Save("Boost", 1);
            upgradeData.boostLevel = true;
			DisableUpgrade(boost, upgradedColor, null);
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

	public void IncreaseValue(UpgradeData upgradeData, int amount)
	{
		upgradeData.moneyAmount += amount;

	}

	public void LoadScene(string name)
	{
		SceneManager.LoadScene(name);
	}

	public void DisableUpgrade(Image image, Color upgradedColor, UpgradeForm form)
	{
		image.color = upgradedColor;

		if (form == null) return;
		form.cost = 0;
	}
}

