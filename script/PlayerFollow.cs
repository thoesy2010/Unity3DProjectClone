using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerFollow : MonoBehaviour {
    public GameObject player;
    public GameObject club;
    private Vector3 offset;//for main cam
    private Vector3 offset2;//for over viewcam
    private Quaternion StartingCam;
    public Camera Main_Camera;

    public Camera Overview_Camera;
    private bool camSwitch;
    private Vector2 touchOrigin = -Vector2.one;

    // Use this for initialization
    void Start () {
        // var a: asd = GetComponent(asd.paul); 


        StartingCam = Main_Camera.transform.rotation;
        offset = Main_Camera.transform.position - player.transform.position;//main cam looks at ball
        offset2 = Overview_Camera.transform.position- club.transform.position;//over view cam looks at club
        Main_Camera.enabled = true;//cam on 
        Overview_Camera.enabled = false;//cam off 
        camSwitch = false;
    }
	
	// Update is called once per frame
	void Update () {
        Main_Camera.transform.position = player.transform.position + offset;
        Overview_Camera.transform.position = club.transform.position + offset2;
        #if UNITY_STANDALONE || UNITY_WEBPLAYER
                if (Input.GetKey("z"))
                {
                    transform.Rotate(0, 1, 0);
                }
                else if (Input.GetKey("x"))
                {
                    transform.Rotate(0, -1, 0);
                }
        #else
                    //float moveAxis;
                if (Input.touchCount > 0)
                {
                    Touch myTouch = Input.touches[0];
                    if (myTouch.phase == TouchPhase.Began)
                    {
                        touchOrigin = myTouch.position;
                    }
                    else if ((myTouch.phase == TouchPhase.Ended) && (touchOrigin.x >= 0))
                    {
                        Vector2 touchEnd = myTouch.position;
                        float x = touchEnd.x - touchOrigin.x;
                        float y = touchEnd.y - touchOrigin.y;
                        touchOrigin.x = -1;
                if (Mathf.Abs(x) > Mathf.Abs(y))//swiping horizontaly more than vertically
                {
                    Debug.Log("x is "+x);
                    if (x > 300) { Main_Camera.transform.Rotate(0, -10, 0); }
                    else { Main_Camera.transform.Rotate(0, 10, 0); }
                }
                else if(Mathf.Abs(y) > Mathf.Abs(x))
                {
                    Debug.Log("y is "+y);
                    if (y > 300) { Main_Camera.transform.Rotate(10, 0, 0); }
                    else { Main_Camera.transform.Rotate(-10, 0, 0); }
                }


            }
        #endif
        }
    }
    public void clickLeft()
    {
        transform.Rotate(0, -5, 0);
    }
    public void clickRight()
    {
        transform.Rotate(0, 5, 0);
    }
    public void SwitchCam() {
        if (camSwitch == true)
        {
            Main_Camera.transform.rotation = StartingCam;
            Main_Camera.enabled = true;//主摄像机开启  
            Overview_Camera.enabled = false;//副摄像关闭
            camSwitch = false;
        }
        else {
            Main_Camera.enabled = false;//主摄像机关闭  
            Overview_Camera.enabled = true;//副摄像机开启 
            camSwitch = true;
            //asd.paul = false;
           // Time.timeScale = 1;

        }
    }
}
