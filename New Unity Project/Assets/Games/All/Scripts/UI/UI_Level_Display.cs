using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Level_Display : MonoBehaviour {

    public static UI_Level_Display ui_level_display;
    public Image background;

    void Start()
    {
        if(ui_level_display == null)
        {
            ui_level_display = this;
        }
        else
        {
            Debug.Log("UI Level Display already exists.");
        }
    }

    public void Update_Level_Display(int _current_level, int _max_level)
    {
        float fill_amount = (float)_current_level / (float)_max_level;
        print(fill_amount);
        background.fillAmount = fill_amount;
    }
}
