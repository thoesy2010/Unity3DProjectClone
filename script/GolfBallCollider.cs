using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GolfBallCollider : MonoBehaviour {//this is the  script for the ball
    private int count;
    public Text CountText;
    public Text WinText;
    public Transform ClubObj;

    private Rigidbody ball;
    public GameObject mahBall;
    private Vector3 offset;
    
    bool isHit = false;
    // Use this for initialization
    void Start () {
        offset =  mahBall.transform.position -  ClubObj.position;
        WinText.text = "";
        count = 0;
        GetCountText();
    }
	
	// Update is called once per frame
	void Update () {
        GetCountText();
        //---------------------------------------
        ball = GetComponent<Rigidbody>();//this golf ball
        var vel = ball.velocity;      //to get a Vector3 representation of the velocity
        float speed = vel.magnitude;
        //---------------------------------------
        if ((isHit==true)&& (speed < 1))
        {//when we press the space bar, a new club will respawn
            ResetBat();
        }
    }
    public void ResetBat() {
        var vel2 = ball.velocity;
        float speed = vel2.magnitude;
       // if ((isHit == true) && (speed < 1))
      //  {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);//stop ball movement when reset
            ClubObj.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);//stop club movement
            ClubObj.transform.position = mahBall.transform.position + offset;//put club to the same starting position
            // Instantiate(ClubObj, transform.position, ClubObj.rotation);
            isHit = false;
      //  }
    }
    void OnCollisionEnter(Collision col)
    {
        
      //  if (col.gameObject.CompareTag("topJoint")){
        //   isHit = true;
           count++;
          // Destroy(col.gameObject);
      //  }
    }
    void OnTriggerEnter(Collider other)
    {  
        if (other.gameObject.CompareTag("Goal"))//when ball get into the hole
        {
            other.gameObject.SetActive(false);
            WinText.text = "YOU WON!!!! YOU'VE USED "+ count+" HITS!!";
            //Debug.Log("Completed!");
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }
    }
    void GetCountText() {
        CountText.text = "Count: " + count;
    }
}