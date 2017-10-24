using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BP_Difficulty_Controller : Difficulty_Controller {

    public int[] balloons_to_use;

    public int Get_Balloons_To_use()
    {
        return balloons_to_use[current_level];
    }
}
