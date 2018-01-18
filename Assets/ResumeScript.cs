using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeScript : MonoBehaviour {

	public void UnPause(){
		MainUI.paused = !MainUI.paused;
	}
}
