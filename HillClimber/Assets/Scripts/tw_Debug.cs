using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tw_Debug : MonoBehaviour {

	//[SerializeField]
	private tw_InputManager tw_inputManager;

	// Use this for initialization
	void Start () {
		tw_inputManager = GetComponent<tw_InputManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (tw_inputManager.E ()) {
			print ("E");
		}
	}
}
