using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BP_Balloon_Hit : MonoBehaviour {

    public void On_Hit()
    {
        if(GetComponent<BP_Balloon_Value_Controller>() != null && BP_Game_Controller.game_controller != null)
        {
            print("HAS VAL");
            print(GetComponent<BP_Balloon_Value_Controller>().Get_Value());
            Selection.activeObject = this.gameObject;
            BP_Game_Controller.game_controller.Answer_Check(GetComponent<BP_Balloon_Value_Controller>().Get_Value());
        }
    }
}
