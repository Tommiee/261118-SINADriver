using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MoneyCount : MonoBehaviour {

	Data data;

	public TextMeshProUGUI moneyText;

	private string zero = ": 0";

	private void Awake()
	{
		data = FindObjectOfType<Data>();
	}

	private void Update()
	{
		if (data.Money >= 10)
		{
			zero = ": ";
		}
		else if (data.Money >= 100)
		{
			zero = ": 0";
		}
		else if (data.Money >= 1000)
		{
			zero = ": 00";
		}
		moneyText.text = zero + data.Money.ToString();
	}
}
