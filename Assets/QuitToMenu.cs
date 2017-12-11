using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitToMenu : MonoBehaviour {

	// Use this for initialization
	public void quitToMenu()
	{
		SceneManager.LoadScene(0);
	}
}
