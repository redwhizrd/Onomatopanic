using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CameraScript : MonoBehaviour {
    Camera camera;
	// Use this for initialization
	void Start () {
        camera = gameObject.GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
	    //camera.transform.position = Stage.
	}
}
