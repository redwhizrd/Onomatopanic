using UnityEngine;
using System.Collections;

public class Player : ScriptableObject
{
	public GameObject go;

	public Player(){
		
	}
	public void OnEnable(){
		go = Instantiate(Resources.Load("Objects/Players/FighterOne")) as GameObject;
//		go.GetComponent<SpriteRenderer>().sprite = Main.Game.
	}
}