using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

using UnityEngine.UI;
using System;
public class ComboCounterScript : MonoBehaviour {
	public enum Combo{
		None,
		Player1,
		Player2
	}
	public Combo ComboState;
	// Use this for initialization
	void Start () {
		ComboState = Combo.None;
	}
	
	// Update is called once per frame
	void Update () {
		if(ComboState==Combo.Player1){
			this.GetComponent<Text>().color = Color.red;
		}	
		else if(ComboState==Combo.Player2){
			this.GetComponent<Text>().color = Color.blue;
		}
	}
}
