using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asd : MonoBehaviour {
    public Rigidbody rb;

    public float speedx;
    public float speedy;
    public float speedz;
    public bool paul;
    public Camera Main_Camera;
    //private GameObject camera0;
    // private GameObject camera1;
    // Use this for initialization
    void Start() {
        
        paul = false;
        Time.timeScale = 1;
        rb = GetComponent<Rigidbody>();
    }   
   
    private void Move()
    {
        if ((paul == false) && (Main_Camera.enabled == true))//no acc input while paused or using overview!
        {
            rb.AddForce(Input.acceleration.x * speedx, Input.acceleration.y * speedz, Input.acceleration.z * speedz, ForceMode.Force);
        }
        /**
        else
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }**/

    }
    // Update is called once per frame
    void Update()
    {
        Move();
    }
    public void Freeze()
    {
        if (paul == false)
        {
            Time.timeScale = 0;
            paul = true;
        }
        else
        {
            Time.timeScale = 1;
            paul = false;
        }

    }
}
