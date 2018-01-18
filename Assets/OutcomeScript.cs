using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OutcomeScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if(Game.end == Game.Ending.PlayerOneWin){
			GameObject.Find("OutcomeText").GetComponent<Text>().text = "Player One WINS!";
		}
		else if(Game.end == Game.Ending.PlayerTwoWin){

			GameObject.Find("OutcomeText").GetComponent<Text>().text = "Player Two WINS!";
		}

		Game.end = Game.Ending.None;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
