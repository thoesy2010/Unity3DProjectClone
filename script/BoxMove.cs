using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMove : MonoBehaviour {
    public float amount = 50f;
    public Rigidbody rb;
    public float torque;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

        // transform.Translate(Input.acceleration.x, 0, -Input.acceleration.z);
        float h = Input.GetAxis("Horizontal") * amount * Time.deltaTime;
        float v = Input.GetAxis("Vertical") * amount * Time.deltaTime;

        rb.AddTorque(transform.up * h);
        rb.AddTorque(transform.right * v);
    }
}
