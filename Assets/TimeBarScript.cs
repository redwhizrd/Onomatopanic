using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeBarScript : MonoBehaviour {

    public float length = 0;
    Slider s;
    float start;
    float end;
	// Use this for initialization
	void Start() {
	    /*if(length == 0)
        {
            length = 30;
        }
        end = Time.realtimeSinceStartup+ length;*/

        s = gameObject.GetComponent<Slider>();
	}
	
	// Update is called once per frame
	void Update () {
        if (s.value >= 0) { 
            s.value = (end - Time.realtimeSinceStartup) / length;
        }
    }

    public void Reset(float seconds)
    {
        length = seconds;
        end = Time.realtimeSinceStartup + length;
    }

}
