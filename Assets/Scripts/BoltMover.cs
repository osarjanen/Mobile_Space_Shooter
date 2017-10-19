using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltMover : MonoBehaviour {

    private float speed; //ammo speed

	void Start ()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        speed = 20.0f;
        rb.velocity = transform.forward * speed;
	}
	

}
