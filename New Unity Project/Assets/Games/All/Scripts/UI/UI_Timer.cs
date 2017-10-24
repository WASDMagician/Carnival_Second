using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Timer : MonoBehaviour {

    public static UI_Timer ui_timer;
    public Text ui_text;

	// Use this for initialization
	void Start () {
        if(ui_timer == null)
        {
            ui_timer = this;
        }
	}
	
	public void Set_Time(string _time)
    {
        if(ui_text != null)
        {
            ui_text.text = _time;
        }
        else
        {
            Debug.Log("UI Text not found.");
        }
    }
	
	void Update()
	{
		
	}
}
