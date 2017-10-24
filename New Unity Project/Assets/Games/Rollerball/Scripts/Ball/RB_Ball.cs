using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RB_Ball : MonoBehaviour {

    Rigidbody ball_rigidbody;
    Vector3 spawn_tile_offset = new Vector3(0, 0.5f, 0);
    private void Start()
    {
        ball_rigidbody = GetComponent<Rigidbody>();
    }

    public void Respawn()
    {
        if(RB_Spawn_Tile.spawn_tile != null)
        {
            RB_Game_Controller.game_controller.Reset_Board_Rotation();
            ball_rigidbody.velocity = Vector3.zero;
            this.transform.position = RB_Spawn_Tile.spawn_tile.transform.position + spawn_tile_offset;
        }
    }

    public void Launch(Vector3 _direction, float _force)
    {
        if(ball_rigidbody == null)
        {
            ball_rigidbody = GetComponent<Rigidbody>();
        }
        if(ball_rigidbody != null)
        {
            ball_rigidbody.AddForce(_direction * _force, ForceMode.Impulse);
        }
        else
        {
            Debug.Log("RB: Ball rigidbody not found.");
        }
    }
}
