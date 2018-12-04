using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tw_Buttons : MonoBehaviour {

	public void LoadScene(){
		SceneManager.LoadScene (0);
	}

	public void ReloadScene(){
		SceneManager.LoadScene ((string)SceneManager.GetActiveScene().name);
	}
}
