using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RB_UI_Difficulty_Display : MonoBehaviour {

    public static RB_UI_Difficulty_Display difficulty_display;
    public Image background;

	// Use this for initialization
	void Start () {
		if(difficulty_display == null)
        {
            difficulty_display = this;
        }
	}
	
    public void Set_Difficulty_Amounts(int _current_val, int _max_val)
    {
        float percent = (float)_current_val / (float)_max_val;
        background.fillAmount = percent;
    }
}
