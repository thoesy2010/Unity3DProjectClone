using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour {
    //private Vector2 touchOrigin = -Vector2.one;
    float horizontal;
    float veritical;
    // Use this for initialization
    void Start () {
		
	}
    // Update is called once per frame
    void Update()
    {
        /**
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
                    if (x > 0) { transform.Rotate(0, -5, 0); }
                    else { transform.Rotate(0, 5, 0); }
                }
            }
        }
    #endif **/
    }
    public void rotateLeft() {
        transform.Rotate(0, -5, 0);
    }
    public void rotateRight()
    {
        transform.Rotate(0, 5, 0);
    }

}

