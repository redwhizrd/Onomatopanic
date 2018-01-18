using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FightBegin : MonoBehaviour {


	// Use this for initialization
	public void loadScene () {
		
		SceneManager.LoadScene ("Resources/Stages/Fight", LoadSceneMode.Single);
	}

}
