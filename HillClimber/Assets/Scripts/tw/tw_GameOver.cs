using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class tw_GameOver : MonoBehaviour {

	[SerializeField]
	LayerMask layerMask;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.up), 5, layerMask);

		Debug.DrawRay (transform.position, transform.TransformDirection(Vector2.up) * 5);

		if (hit.collider != null ) {
			print ("hit something");
			print (hit.collider);
		}
	}
}