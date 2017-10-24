using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RB_Bounce : MonoBehaviour {

    public float force;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        RB_Ball ball = collision.gameObject.GetComponent<RB_Ball>();
        if(ball != null)
        {
            ball.Launch(-(this.transform.position - ball.transform.position), force);
        }

    }
}
