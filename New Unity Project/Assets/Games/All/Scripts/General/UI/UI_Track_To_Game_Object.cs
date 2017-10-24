using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Track_To_Game_Object : MonoBehaviour {

    public GameObject object_to_follow;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Track();
	}

    void Track()
    {
        if(object_to_follow != null)
        {
            this.transform.position = Camera.main.WorldToScreenPoint(object_to_follow.transform.position);
        }
    }
}
