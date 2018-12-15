using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public GameObject winPanel;
	public GameObject losePanel;

	// Use this for initialization
	void Start () {
		Time.timeScale = 1f;
	}

	public void ActivateSwitch(GameObject activateObject)
	{
		if (!activateObject.activeSelf)
		{
			activateObject.SetActive(true);
			//Time.timeScale = 0;
		}
	}
}
