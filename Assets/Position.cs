using UnityEngine;
using System.Collections;

public class Position : MonoBehaviour
{
	public int number;
	public Effect effect;
	private Fighter effectOwner;

	void Start(){
		effect = null;
		setSpecial(null);
	}

	void Update(){
		if(effect!=null){
			gameObject.GetComponent<SpriteRenderer>().color = Color.red;
		}
		else{
			gameObject.GetComponent<SpriteRenderer>().color = Color.grey;
		}
	}

	public void setSpecial(Fighter f){
		
		if(f==null){
			//set color to black
			//gameObject.GetComponent<SpriteRenderer>().color = Color.black;
		}
		else{
	
			effectOwner = f;
		
			effect = f.getSpecial();
			//set color to red
			//gameObject.GetComponent<SpriteRenderer>().color = Color.red;
		}
	}

	public Effect getSpecial(){
		return effect;
	}

	public void setPosition(Vector3 newpos){
		this.gameObject.transform.position = newpos;
	}

	public Vector3 getPosition()
	{
		return this.gameObject.transform.position;
	}



	public bool shouldPush(Fighter f){
		if(effect!=null){
			bool ret=  effect.shouldPush(effectOwner, f);
			if(ret==true){
				effect = null;
			}
			return ret;
		}
		else
			return true;
	}
}