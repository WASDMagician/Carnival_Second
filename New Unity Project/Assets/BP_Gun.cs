using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BP_Gun: MonoBehaviour {

    public GameObject point_at;
    public GameObject firing_point;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //this.transform.LookAt(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)));
        this.transform.LookAt(point_at.transform.position);
        if(Input.GetMouseButtonUp(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(firing_point.transform.position, firing_point.transform.forward);
            if(hit.collider != null)
            {
                BP_Balloon_Hit hit_controller = hit.collider.gameObject.GetComponent<BP_Balloon_Hit>();
                if(hit_controller != null)
                {
                    print("HIT OBJECt");
                    hit_controller.On_Hit();
                }
            }
        }
    }
}
