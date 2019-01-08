using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour {

	public UpgradeData upgradeData;
	public GameObject boostMeter;
	public Text triesAmount;

	void Start () {
		if (upgradeData.boostLevel) return;
		boostMeter.SetActive(false);
	}
	
	void Update () {
		triesAmount.text = upgradeData.triesLeft.ToString();
	}
}
