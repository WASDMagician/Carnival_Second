using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Difficulty_Controller : MonoBehaviour {

    public int current_level, max_level;
    public int[] digits_to_use, min_num_to_use, max_num_to_use;
    UI_Level_Display ui_level_display;

    private void Start()
    {
        ui_level_display = UI_Level_Display.ui_level_display;
    }

    public int Get_Current_Level()
    {
        return current_level;
    }

    public int Get_Max_Level()
    {
        return max_level;
    }

    public int Get_Digits_To_Use()
    {
        return digits_to_use[current_level ];
    }

    public int Get_Min_Num_To_Use()
    {
        return min_num_to_use[current_level];
    }

    public int Get_Max_Num_To_Use()
    {
        return max_num_to_use[current_level];
    }

    public void Increment_Level()
    {
        if(current_level + 1 < max_level)
        {
            if(ui_level_display == null)
            {
                ui_level_display = UI_Level_Display.ui_level_display;
            }
            if (ui_level_display != null)
            {
                ui_level_display.Update_Level_Display(current_level, max_level);
            }
            else
            {
                Debug.Log("UI Level Display not found.");
            }
            current_level++;
        }
        else
        {
            if(ui_level_display != null)
            {
                ui_level_display.Update_Level_Display(max_level, max_level);
            }
            Debug.Log("Max level reached.");
        }
    }

    public void Decrement_Level()
    {
        if (current_level - 1 >= 0)
        {
            current_level--;
            if (ui_level_display == null)
            {
                ui_level_display = UI_Level_Display.ui_level_display;
            }
            if (ui_level_display != null)
            {
                ui_level_display.Update_Level_Display(current_level, max_level);
            }
            else
            {
                Debug.Log("UI Level Display not found.");
            }
            
        }
        else
        {
            Debug.Log("Min level reached.");
        }
    }
}
