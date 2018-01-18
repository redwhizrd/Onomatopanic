using UnityEngine;
using System.Collections;

public class Defense : MonoBehaviour, Effect
{

	public bool broken;
	public Defense(){
		broken = false;
	}
	public bool shouldPush(Fighter owner, Fighter opposition){
		if(opposition.first==owner.first){
			return false;
		}
		if(!broken){
			broken = true;
			return false;
		}
		else{
			return true;
		}
	}
	public void reset(){
		broken = false;	
	}
}

