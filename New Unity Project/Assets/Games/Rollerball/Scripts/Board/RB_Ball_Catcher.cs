using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RB_Ball_Catcher : MonoBehaviour {

    public float spawn_time;

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
            StartCoroutine(Respawn(ball));
        }
    }

    IEnumerator Respawn(RB_Ball _ball)
    {
        yield return new WaitForSeconds(spawn_time);
        _ball.Respawn();
        
    }
}
