using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour  {

	// Use this for initialization
	public void loadScene () {
		SceneManager.LoadScene ("Options", LoadSceneMode.Single);
	}
	
}
