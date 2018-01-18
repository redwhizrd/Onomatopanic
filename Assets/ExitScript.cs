using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitScript : MonoBehaviour  {

	// Use this for initialization
	public void loadScene () {
		SceneManager.LoadScene ("MainMenu", LoadSceneMode.Single);
	}
}
