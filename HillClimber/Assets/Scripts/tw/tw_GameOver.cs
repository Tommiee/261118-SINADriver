using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class tw_GameOver : MonoBehaviour {

	[SerializeField]
	private LayerMask layerMask;
	[SerializeField]
	private string nextScene;

	// Update is called once per frame
	void Update () {
		RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.up), 5, layerMask);

		Debug.DrawRay (transform.position, transform.TransformDirection(Vector2.up) * 5);

		if (hit.collider != null ) {;
			GameOver ();
		}
	}

	void GameOver(){
		print ("hit something");
		SceneManager.LoadScene (nextScene);
	}
}