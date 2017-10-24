using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RB_Hole_Tile : MonoBehaviour {

    float time_in = 0.0f;
    public float time_stay_limit = 1.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionStay(Collision collision)
    {
        RB_Ball ball = collision.gameObject.GetComponent<RB_Ball>();
        if (ball != null)
        {
            time_in += Time.deltaTime;
            if (time_in >= time_stay_limit)
            {
                ball.Respawn();
                time_in = 0.0f;
            }
        }
    }
}
