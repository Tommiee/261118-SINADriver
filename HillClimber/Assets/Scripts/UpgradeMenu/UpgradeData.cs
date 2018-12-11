using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "UpgradeData", menuName = "Upgrades Data", order = 1)]
public class UpgradeData : ScriptableObject
{
    public int motorLevel;
    public int gripLevel;
    public int batteryLevel;
    public bool boostLevel;
    public int currencyLevel;
    public bool solarPanelsLevel;

}