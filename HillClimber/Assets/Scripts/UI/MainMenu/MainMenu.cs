using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public UpgradeData upgradeData;
	public PhysicsMaterial2D tires;

	private void Start()
	{
		Reset();
	}

	public void LoadScene(string name)
	{
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
