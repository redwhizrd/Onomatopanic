using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSelect : MonoBehaviour  {

	// Use this for initialization
	public void loadScene () {
		SceneManager.LoadScene ("PlayerSelect", LoadSceneMode.Single);
	}

}
