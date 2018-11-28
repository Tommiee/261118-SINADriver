using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wc_Hotkeys : MonoBehaviour {

	public GameObject player;

	Vector3 startPos;

	// Use this for initialization
	void Start () {
		startPos = player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.R))
		{
			player.transform.position = startPos;
		}
	}
}
