using UnityEngine;
using System.Collections;

public class Height : MonoBehaviour, Effect
{
	public Height(){

	}

	public bool shouldPush(Fighter owner, Fighter opposition){
		if(opposition.height==State.Height.Low){
			return false;
		}
		return true;
	}


	public void reset(){

	}
}

