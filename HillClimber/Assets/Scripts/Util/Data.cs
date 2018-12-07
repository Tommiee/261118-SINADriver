using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour {

	[SerializeField] private float money = 0f;

	public float Money {
		get
		{
			return money;	
		}
	}

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AddMoney(int value)
	{
		money += value;
		//Debug.Log(money);
	}
}
