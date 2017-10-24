using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RB_Board_Rotation : MonoBehaviour {

    public Transform rotation_point;
    float speed = 10;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        Handle_Input();
	}

    void Handle_Input()
    {
#if UNITY_EDITOR
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        this.transform.RotateAround(rotation_point.position, Vector3.right, vertical);
        this.transform.RotateAround(rotation_point.position, Vector3.forward, -horizontal);
        //fix y rotation
        Vector3 rotation = this.transform.rotation.eulerAngles;
        rotation.y = 0;
        this.transform.rotation = Quaternion.Euler(rotation);
#endif
#if UNITY_ANDROID && !UNITY_EDITOR
        transform.rotation = new Quaternion(Input.acceleration.x, Input.acceleration.z, Input.acceleration.y, 0);

#endif
    }
}
