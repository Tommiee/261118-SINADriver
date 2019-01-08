using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour {

	public UpgradeData upgradeData;

	[SerializeField] private int money = 0;

	public int Money {
		get
		{
			return money;	
		}
	}

	private void Start()
	{
		money = upgradeData.moneyAmount;
	}

	public void AddMoney(int value)
	{
		money += value;
		upgradeData.moneyAmount = money;
	}
}
