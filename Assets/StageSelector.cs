using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageSelector : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//fill up gameobject screen with stages
		//9 stages in 3x3 array?
		GameObject stagescreen = GameObject.Find("StageScreen");

		Object[] bgList = Resources.LoadAll<Sprite>("Stages/Background");

		int counter = 0;
		Vector3 lowerleft = stagescreen.transform.position;
		RectTransform rt = (RectTransform)stagescreen.transform;
		for(int col = 1; col <= 3; col++){
			for(int row = 1; row <= 3; row++){
					///
				GameObject go = GameObject.Instantiate(Resources.Load("Stages/StageSelectButtonPrefab")) as GameObject;

				if(counter<bgList.Length){
					go.name = bgList[counter].name;

					go.GetComponent<Image>().sprite = (Sprite)bgList[counter];
				
				}
				go.GetComponent<Button>().onClick.AddListener(() => {
					Game.stage = new StageInfo(go.name);
					go.GetComponent<Button>().Select();
				});
				//

				//
				float x = (rt.rect.width*col/4)-(((RectTransform)go.transform).rect.height/2);
			
				float y = (rt.rect.height*row/4)-(((RectTransform)go.transform).rect.width/2);
			
				go.transform.position = new Vector3(x,y,2);

				go.transform.parent = stagescreen.transform;
				counter++;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}


}
