using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WAM_Game_Controller : Game_Controller {

    public static WAM_Game_Controller game_controller;

    WAM_Mole_Controller[] mole_controllers;
    WAM_Game_State_Controller game_state;
    WAM_Difficulty_Controller difficulty_controller;

	// Use this for initialization
	void Start () {
        if(game_controller == null)
        {
            game_controller = this;
        }
        //get moles
        mole_controllers = GameObject.FindObjectsOfType<WAM_Mole_Controller>();
        if(WAM_Game_State_Controller.wam_game_state != null && WAM_Difficulty_Controller.difficulty_controller != null && mole_controllers.Length > 0)
        {
            difficulty_controller = WAM_Difficulty_Controller.difficulty_controller;
            game_state = WAM_Game_State_Controller.wam_game_state;
            StartCoroutine(Activate_Moles()); //start moles rising and falling
        }
        else
        {
            Debug.Log("WAM: Game state not found or no mole controllers found.");
        }
	}

    IEnumerator Activate_Moles()
    {
        if(game_state.Get_State() == WAM_Game_State_Controller.WAM_States.playing) //if game is in play
        {
            for (int i = 0; i < mole_controllers.Length; i++) //iterate over all moles
            {
                if (mole_controllers[i].Get_Mole_Raised() == false) //if mole has not already been raised
                {
                    int rand = Random.Range(0, 10); //get rand num
                    if(rand == 1) //if num == 1
                    {
                        mole_controllers[i].Activate_Mole(difficulty_controller.Get_Addition(), difficulty_controller.Get_Mole_Raise_Time()); //raise mole
                        break;
                    }
                }
            }
        }
        yield return new WaitForSeconds(difficulty_controller.Get_Mole_Wait_Time()); //wait for an amount of time
        StartCoroutine(Activate_Moles()); //try to raise mole again
    }
}
