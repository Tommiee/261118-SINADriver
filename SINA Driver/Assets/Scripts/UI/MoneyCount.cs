using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MoneyCount : MonoBehaviour {

	public UpgradeData upgradeData;

	public TextMeshProUGUI moneyText;

	private string zero = ": 0";
	
	private void Update()
	{
		if (upgradeData.moneyAmount >= 10)
		{
			zero = ": ";
		}
		moneyText.text = zero + upgradeData.moneyAmount.ToString();
	}
}
