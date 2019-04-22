using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//[DisallowMultipleComponent]
//[RequireComponent(typeof(SpriteRenderer))]
public class button : MonoBehaviour {
    // []
    bool paul = false;

    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Freeze()
    {
        if (paul == false)
        {
            Time.timeScale = 0;
            paul = true;
        }
        else {
            Time.timeScale = 1;
            paul = false;
        }

    }
    
}
