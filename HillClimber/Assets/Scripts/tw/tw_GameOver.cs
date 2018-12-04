using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class tw_GameOver : MonoBehaviour {

	[SerializeField] private LayerMask layerMask;
	[SerializeField] private GameObject[] activateObjects;

	void Update () {
		RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.up), 5, layerMask);

		Debug.DrawRay (transform.position, transform.TransformDirection(Vector2.up) * 5);

		if (hit.collider != null ) {;
			GameOver ();
		}
	}

	public void GameOver(){
		for (int i = 0; i < activateObjects.Length; i++) {
			if (!activateObjects[i].activeSelf)
			{
				print(activateObjects[i]);
				activateObjects[i].SetActive(true);
			}
		}
	}
}