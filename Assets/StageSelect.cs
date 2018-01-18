using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelect : MonoBehaviour  {

	// Use this for initialization
	public void loadScene () {
		SceneManager.LoadScene ("StageSelect", LoadSceneMode.Single);
	}

}
