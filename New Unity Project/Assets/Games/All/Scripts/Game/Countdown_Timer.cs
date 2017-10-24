using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Countdown_Timer : MonoBehaviour {

    UI_Timer ui_timer;
    public float raw_seconds;

    private void Start()
    {
        if(ui_timer == null)
        {
            ui_timer = UI_Timer.ui_timer;
        }
    }

    private void Update()
    {
        if(ui_timer == null)
        {
            ui_timer = UI_Timer.ui_timer;
        }
        if (ui_timer != null)
        {
            raw_seconds -= Time.deltaTime;
            int minutes = Seconds_To_Minutes();
            int seconds = Seconds_To_Seconds(minutes);
            ui_timer.Set_Time(Time_String(minutes, seconds));
        }
		
    }

    int Seconds_To_Minutes()
    {
        return (int)raw_seconds / 60;
    }

    int Seconds_To_Seconds(int _minutes)
    {
        int secs = (int)raw_seconds - (_minutes * 60);
        return secs;
    }

    string Time_String(int _minutes, int _seconds)
    {
        string string_time = "";
        string string_minutes = "";
        string string_seconds = "";
        if(_seconds < 10)
        {
            string_seconds += 0.ToString();
        }
        string_seconds += _seconds.ToString();
        string_minutes = _minutes.ToString();
        string_time = string_minutes + ":" + string_seconds;
        return string_time;
    }
}
