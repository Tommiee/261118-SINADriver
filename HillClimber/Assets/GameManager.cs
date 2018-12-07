using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public Text winText;
	public Text loseText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Stop(GameObject activateObject)
	{
		if (!activateObject.activeSelf)
		{
			activateObject.SetActive(true);
			//Time.timeScale = 0;
		}
	}

	public void Lose()
	{
		
	}
}
