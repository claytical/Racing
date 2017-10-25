using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jetski : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.LeftArrow)) {
			
			transform.Rotate (0, 0, -.01f);
		}
		if (Input.GetKey(KeyCode.RightArrow)) {
			transform.Rotate (0, 0, .01f);
		}

		if (Input.GetKey (KeyCode.UpArrow)) {
			//model is rotated 90 degrees, otherwise we'd use transform.forward
			transform.position += transform.up * .1f;
		}
	}
}
