using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelectButton : MonoBehaviour
{
	
	public void loadScene(string s){
		Game.stage = new StageInfo(s);
		SceneManager.LoadScene ("Resources/Stages/Fight", LoadSceneMode.Single);
	}
}

