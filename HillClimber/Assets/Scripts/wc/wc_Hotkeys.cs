using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class wc_Hotkeys : MonoBehaviour {

	public GameObject player;
	public GameObject winText;
	public GameObject loseText;

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
			winText.SetActive(false);
			loseText.SetActive(false);
			Time.timeScale = 1;
		}
	}
}
