using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Unlock : MonoBehaviour  {

	// Use this for initialization
	public void loadScene () {
		SceneManager.LoadScene ("Unlock", LoadSceneMode.Single);
	}

}
