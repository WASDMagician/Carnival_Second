using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RB_Difficulty_Controller : Difficulty_Controller {

    public int current_level, max_level;
    public int[] num_digits_to_use;
    public int[] min_number_to_use;
    public int[] max_number_to_use;

    public int Get_Num_Digits_To_Use()
    {
        return num_digits_to_use[current_level];
    }

    public int Get_Min_Num_To_Use()
    {
        return min_number_to_use[current_level];
    }

    public int Get_Max_Num_To_Use()
    {
        return max_number_to_use[current_level];
    }

    public void Increment_Level()
    {
        RB_UI_Difficulty_Display.difficulty_display.Set_Difficulty_Amounts(current_level + 1, max_level);
        current_level++;
    }

    public bool Can_Increment_Level()
    {
        return current_level + 1 < max_level;
    }
}
