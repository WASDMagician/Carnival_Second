using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RB_Answer_Tile : RB_Tile {
    public RB_Number_Tile number_tile;
	
    public void Set_Tile_Value(int _value)
    {
        if(number_tile != null)
        {
            number_tile.Set_Tile_Value(_value);
        }
        else
        {
            Debug.Log("RB: Cannot find number tile.");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<RB_Ball>())
        {
            if (RB_Game_Controller.game_controller != null)
            {
                RB_Game_Controller.game_controller.Answer_Hit();
            }
        }
    }
}
