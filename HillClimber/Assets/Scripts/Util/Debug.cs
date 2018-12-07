using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debug : MonoBehaviour {

	//[SerializeField]
	private InputManager inputManager;

	// Use this for initialization
	void Start () {
		inputManager = GetComponent<InputManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (inputManager.E ()) {
			print ("E");
		}

		if (inputManager.Escape ()) {
			print ("Escape");
		}
	}
}
