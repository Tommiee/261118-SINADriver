using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public UpgradeData upgradeData;
	public PhysicsMaterial2D tires;

	// Ensures that people repay before they replay
	[SerializeField] private KeyCode readyKey;
	bool ready;

	private void Start()
	{
		Reset();
		ready = false;
	}

	private void Update()
	{
		if (Input.GetKeyDown(readyKey) || readyKey == KeyCode.None) ready = true;
	}

	public void LoadScene(string name)
	{
		if (name == "Main" && !ready) return;
		SceneManager.LoadScene(name);
	}

	public void Reset()
	{
		upgradeData.motorLevel = 0;
		upgradeData.gripLevel = 0;
		upgradeData.batteryLevel = 0;
		upgradeData.boostLevel = false;
		upgradeData.currencyLevel = 0;
		upgradeData.solarPanelsLevel = false;
		upgradeData.moneyAmount = 0;
		upgradeData.triesLeft = upgradeData.maxTries;
		tires.friction = 0.5f;
	}

	public void Credits()
	{
		//SceneManager.LoadScene(2);
		//Debug.Log("Go to credits scene");
	}

	public void Quit()
	{
#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_WEBPLAYER
			//Application.OpenURL(webplayerQuitURL);
#else
			Application.Quit();
#endif
	}
}
