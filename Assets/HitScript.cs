using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitScript : MonoBehaviour {
	// Use this for initialization
	Animator anim;
	void Start () {
		anim = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void doHit(){
		

	}


	public void resetPunch(){
        anim.SetInteger("punchHeight", 0);
    }
}
