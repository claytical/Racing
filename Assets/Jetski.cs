using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jetski : MonoBehaviour {

    public float speed;
    // Use this for initialization

	void Start () {
        speed = 0f;
	}

    // Update is called once per frame
    void Update()
    {
        if (speed <= 0)
        {
            speed = 0;
        }

        //jetski model is rotated, otherwise we would use transform.forward
        transform.position += transform.up * .1f * speed;


        if (Input.GetKey(KeyCode.LeftArrow))
        {

            transform.Rotate(0, 0, -.01f);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, 0, .01f);
        }

    }

}
