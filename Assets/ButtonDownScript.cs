using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonDownScript : MonoBehaviour {
	public KeyCode key;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(key!=null){
			if(Input.GetKey(key)){
				gameObject.GetComponent<RawImage>().color = Color.red;
			}
			else{
				gameObject.GetComponent<RawImage>().color = Color.black;
			}
		
		}
	}
}
