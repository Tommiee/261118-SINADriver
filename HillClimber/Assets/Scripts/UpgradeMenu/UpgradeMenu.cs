using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;

public class UpgradeMenu : MonoBehaviour
{
    public UpgradeData upgradeData;
    private const int MAX_LEVEL = 3;
    public int[] motorLevel = new int[MAX_LEVEL];
    Data data;

    
    // Use this for initialization
    void Start()
    {
        data = FindObjectOfType<Data>();
        upgradeData.motorLevel = 1;
        

    }

    // Update is called once per frame
    void Update()
    {

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
    public void UpgradeMotorLevel()
    {
        




    }
    void OnValidate()
    {
        if(motorLevel.Length != MAX_LEVEL)
        {
            print("Don't change the size of this array! <3 Jamiro.");
            Array.Resize(ref motorLevel, MAX_LEVEL);

        }
    }

}

