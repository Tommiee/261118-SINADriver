using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

	public UpgradeData upgradeData;
	public GameObject boostMeter;

	void Start () {
		if (upgradeData.boostLevel) return;
		boostMeter.SetActive(false);
	}
	
	void Update () {
		
	}
}
