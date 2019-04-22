using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeController : MonoBehaviour {
    public float moveSpeed = 5.0f;
    public float drag = 0.5f;
    public float terminalRotationSpeed = 25.0f;
    public Vector3 MoveVector { set; get; }
    public joystick Thejoystick;

    private Rigidbody thisRigidbody;


    // Use this for initialization
    private void Start () {
        thisRigidbody = gameObject.GetComponent<Rigidbody>();
        thisRigidbody.maxAngularVelocity = terminalRotationSpeed;
        thisRigidbody.drag = drag;


    }
	
	// Update is called once per frame
	private void Update () {
        MoveVector = PoolInput();
        Move();

	}
    private void Move() {
        Vector3 dir = Vector3.zero;


    }
    private Vector3 PoolInput() {
        Vector3 dir = Vector3.zero;
        //dir.x = Input.GetAxis("Horizontal");
        //dir.z = Input.GetAxis("Vertical");
        dir.x = Thejoystick.Horizontal();
        dir.z = Thejoystick.Vertical();
        if (dir.magnitude > 1)
            dir.Normalize();
        return dir;



    }
}
