using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class tw_GameOver : MonoBehaviour {

	[SerializeField] private LayerMask layerMask;
	public GameObject activateObject;

	// Update is called once per frame
	void Update () {
		RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.up), 5, layerMask);

		Debug.DrawRay (transform.position, transform.TransformDirection(Vector2.up) * 5);

		if (hit.collider != null ) {;
			GameOver ();
		}
	}

	public void GameOver(){
		if (!activateObject.activeSelf)
		{
			activateObject.SetActive(true);
			//Time.timeScale = 0;
		}
	}
}