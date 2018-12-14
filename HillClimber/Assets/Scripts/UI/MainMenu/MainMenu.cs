using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(UpgradeMenu))]
public class MainMenu : MonoBehaviour
{
	private void Start()
	{
		GetComponent<UpgradeMenu>().Reset();
	}

	public void Play()
	{
		SceneManager.LoadScene(1);
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
