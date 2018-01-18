using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUI : MonoBehaviour {
	public static bool paused = false;
	// Use this for initialization
	void Start () {
		paused = false;
		if(!paused){
			gameObject.GetComponent<CanvasGroup>().alpha = 0f;
			gameObject.GetComponent<CanvasGroup>().interactable = false;
		}
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.Escape)){
			Debug.Log("Paused");
					paused = !paused;
		}
		if(paused){
			gameObject.GetComponent<CanvasGroup>().alpha = 1f;
			gameObject.GetComponent<CanvasGroup>().interactable = true;
		}
		else if(!paused){
			gameObject.GetComponent<CanvasGroup>().alpha = 0f;
			gameObject.GetComponent<CanvasGroup>().interactable = false;
		}
	}
}
