using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public GameObject winPanel;
	public GameObject losePanel;
	public GameObject gameOverPanel;
	public UpgradeData upgradeData;
	public PhysicsMaterial2D tires;
	public GameObject booster;

	// Use this for initialization
	void Start () {
		Time.timeScale = 1f;

		if (upgradeData.gripLevel > 0)
		{
			tires.friction = PlayerPrefs.GetInt("Wheels", 1);
		}
		else
		{
			tires.friction = 1;
		}

		if (!upgradeData.boostLevel) booster.SetActive(false);
	}

	public void ActivateSwitch(GameObject activateObject)
	{
		if (!activateObject.activeSelf)
		{
			activateObject.SetActive(true);
		}
	}
}
