using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private Rigidbody rigid;
    public float inputDelay = 0.1f;
    public float forwardVel;
    public float rotateVel;
    public bool KeyPressed;
    public bool isUpPressed = false;
    public bool isDownPressed = false;
    public bool isLeftPressed = false;
    public bool isRightPressed = false;
    public Camera OverView_Camera;
    public GameObject MahBall;
    Quaternion targetRotation;
    Rigidbody rBody;
    private Vector3 offset;

    /*public float speed;
    private Rigidbody rb;
    private Vector3 offset;
    // private Vector2 touchOrigin = -Vector2.one;
    GameObject mahBall;
    float horizontal;
    float veritical;
    float moveAxis;*/

    // Vector3 Speed;
    float forwardInput, turnInput;
    public Quaternion TargetRotation
    {
        get { return targetRotation; }
    }
    void Start()
    {
        KeyPressed = false;
        if (GetComponent<Rigidbody>())
        {
            rBody = GetComponent<Rigidbody>();
        }
        else
        { Debug.LogError("The character needs a rigidbody.");}
        forwardInput = turnInput = 0;
        targetRotation = transform.rotation;

        MahBall = GameObject.Find("MahBall");
        offset = rBody.transform.position - MahBall.transform.position;
    }
    void GetInput()
    {
        if (isUpPressed)
        {
            forwardInput = 1;
        }
        else if (isDownPressed)
        {
            forwardInput = -1;
        }
        else
        {
            forwardInput = 0;
        }
        if (isLeftPressed)
        {
            turnInput = -1;
        }
        else if (isRightPressed)
        {
            turnInput = 1;
        }
        else
        {
            turnInput = 0;
        }
    }
    void Update()
    {
        if (OverView_Camera.enabled == true)
        { // you can only move when the overview camera is ready 
            GetInput();
            Turn();
        }
        else if((forwardInput==0)&&(turnInput==0))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }    
    }
    void FixedUpdate()
    {
        Run();
    }
    void Run()
    {
        if (Mathf.Abs(forwardInput) > inputDelay)
        {
            rBody.MovePosition(transform.position + transform.forward * forwardInput * forwardVel);
        }
        else
        { rBody.velocity = Vector3.zero; }
    }
    void Turn()
    {
        targetRotation = targetRotation * Quaternion.AngleAxis(rotateVel * turnInput * Time.deltaTime, Vector3.up);
        transform.rotation = targetRotation;
    }
    public void onPointerDown_GoUp()
    {
        isUpPressed = true;
    }
    public void onPointerUp_GoUp()
    {
        isUpPressed = false;
        
    }
    public void onPointerDown_GoDown()
    {
        isDownPressed = true;
    }
    public void onPointerUp_GoDown()
    {
        isDownPressed = false;
    }
    public void onPointerUp_GoLeft()
    {
        isLeftPressed = false;
    }
    public void onPointerDown_GoLeft()
    {
        isLeftPressed = true;
    }
    public void onPointerUp_GoRight()
    {
        isRightPressed = false;
    }
    public void onPointerDown_GoRight()
    {
        isRightPressed = true;
    }

    public void ResetPlacing()
    {
        MahBall = GameObject.Find("MahBall");
        Debug.Log("the offset is" + offset);
        transform.position = MahBall.transform.position + offset;
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
    }
}