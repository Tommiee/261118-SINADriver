using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TirePlacement : MonoBehaviour {

	Vector3 localPosition;

	// Use this for initialization
	void Start () {
		localPosition = transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
		transform.localPosition = localPosition;
	}
}
