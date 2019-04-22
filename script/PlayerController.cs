using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    private Vector3 offset;
    // private Vector2 touchOrigin = -Vector2.one;
    GameObject mahBall;
    float horizontal;
    float veritical;
    float moveAxis;

    private void Start()
    {
        mahBall = GameObject.Find("MahBall");
        rb = GetComponent<Rigidbody>();
        offset = transform.position - mahBall.transform.position;

    }

    private void ApplyInput(float moveInput)
    {
        Move(moveInput);
    }
    private void Move(float input)
    {
        rb.AddForce(transform.forward * input * speed, ForceMode.Force);

    }

    public void ResetPlacing()
    {
        mahBall = GameObject.Find("MahBall");
        transform.position = mahBall.transform.position + offset;
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
    }

    void Update()
    {

#if UNITY_STANDALONE || UNITY_WEBPLAYER


        float moveAxis = Input.GetAxis("Vertical");
        ApplyInput(moveAxis);
        if (Input.GetKeyDown("r"))
        {
            mahBall = GameObject.Find("MahBall");
            transform.position = mahBall.transform.position + offset;
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }


    }

#endif
    }
}