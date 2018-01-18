using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class PickButton : MonoBehaviour {

	public static bool charpicking = true;
	public void pickChar(Sprite s)
	{
		Image g;
		if(charpicking){;
			Game.Char1 = this.gameObject.GetComponentInChildren<Text>().text;
			charpicking = false;
			g = GameObject.Find("Player1Char").GetComponent<Image>();

		}
		else{
			Game.Char2 = this.gameObject.GetComponentInChildren<Text>().text;
			charpicking  = true;
			g = GameObject.Find("Player2Char").GetComponent<Image>();
		}

		g.sprite = s;
	}


}
