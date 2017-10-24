using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RB_Number_Tile : RB_Tile {

    Num_Value_Controller num_value_controller;
    int value;

	// Use this for initialization
	void Start () {
        num_value_controller = GetComponentInChildren<Num_Value_Controller>();
	}
	
    public void Set_Tile_Value(int _value)
    {
        value = _value;
        if(num_value_controller == null)
        {
            num_value_controller = GetComponentInChildren<Num_Value_Controller>();
        }
        if(num_value_controller != null)
        {
            num_value_controller.Set_Value(_value);
        }
        else
        {
            Debug.Log("RB: Num value controller not found.");
        }
    }

    public int Get_Tile_Value()
    {
        return value;
    }

    private void OnTriggerEnter(Collider other)
    {
        RB_Ball ball = other.gameObject.GetComponent<RB_Ball>();
        if (ball != null)
        {
            if (RB_Game_Controller.game_controller != null)
            {
                RB_Game_Controller.game_controller.Check_Answer((int)num_value_controller.Get_Value());
            }
        }
    }
}
