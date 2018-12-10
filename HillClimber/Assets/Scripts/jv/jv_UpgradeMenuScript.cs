using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jv_UpgradeMenuScript : MonoBehaviour {
    public UpgradeData upgradeData;
    
	// Use this for initialization
	void Start () {

        upgradeData.motorLevel = 1;


	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Reset()
    {
        upgradeData.motorLevel = 0;
        upgradeData.gripLevel = 0;
        upgradeData.batteryLevel = 0;
        upgradeData.boostLevel = false;
        upgradeData.currencyLevel = 0;
        upgradeData.solarPanelsLevel = false;
}
}
