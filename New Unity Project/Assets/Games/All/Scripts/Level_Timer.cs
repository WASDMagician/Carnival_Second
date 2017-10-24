using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Timer : MonoBehaviour {

    public float start_time_seconds;
    public UI_Timer ui_timer;
    int minutes;
    int seconds;

	// Use this for initialization
	void Start () {
        ui_timer = UI_Timer.ui_timer;
	}
	
	// Update is called once per frame
	void Update () {
        if (ui_timer != null)
        {
            ui_timer.Set_Time(Time_To_String());
            start_time_seconds -= Time.deltaTime;
            if (start_time_seconds <= 0.0f)
            {
                //end game
            }
        }
	}

    string Time_To_String()
    {
        int minutes = (int)start_time_seconds / 60;
        int seconds = (int)start_time_seconds - (minutes * 60);
        string mins = "";
        string secs = "";
        if(minutes < 10)
        {
            mins += 0.ToString();
        }
        mins += minutes.ToString();
        secs += seconds.ToString();
        return mins + ":" + secs;
    }
}
