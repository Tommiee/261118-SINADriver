using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Hotkeys : MonoBehaviour {

	public GameObject player;
	public GameObject winPanel;
	public GameObject losePanel;
	public BatteryAmount battery;
	public bool godmode = true;

	Vector3 startPos;
	Quaternion startRot;

	// Use this for initialization
	void Start () {
		startPos = player.transform.position;
		startRot = player.transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.R))
		{
			player.transform.position = startPos;
			player.transform.rotation = startRot;
			winPanel.SetActive(false);
			losePanel.SetActive(false);
			battery.batteryAmount = battery.maxBatteryAmount;
			Time.timeScale = 1;
		}
		
		if (Input.GetKeyDown(KeyCode.G))
		{
			godmode = !godmode;
			//Debug.Log("Godmode is " + godmode);
		}
	}
}
