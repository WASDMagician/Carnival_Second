using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WAM_Game_State_Controller : Game_State_Controller {

    public static WAM_Game_State_Controller wam_game_state;

    public enum WAM_States { playing, paused, waiting};
    public WAM_States wam_state;
    
    // Use this for initialization
	void Start () {
	    if(wam_game_state == null)
        {
            wam_game_state = this;
        }
	}
	
	public void Set_State(WAM_States _state)
    {
        wam_state = _state;
    }

    public WAM_States Get_State()
    {
        return wam_state;
    }
}
