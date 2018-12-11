using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jv_UpgradeMenuScript : MonoBehaviour {

    const int MAX_LEVEL = 3;

    public UpgradeData upgradeData;
    public List<UpgradeForm> motorUpgrade = new List<UpgradeForm>();

    public void MotorUpgrade() {
        if(upgradeData.motorLevel < MAX_LEVEL) {
            UpgradeForm data = motorUpgrade[upgradeData.motorLevel];
            Debug.Log(data.value + " - " + data.cost);
            upgradeData.motorLevel++;
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
    }
}
