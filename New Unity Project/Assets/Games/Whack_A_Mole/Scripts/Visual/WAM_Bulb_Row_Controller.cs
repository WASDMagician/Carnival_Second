using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WAM_Bulb_Row_Controller : MonoBehaviour {

    public static WAM_Bulb_Row_Controller bulb_row_controller;
    public WAM_Bulb_Controller[] bulb_controllers;

	// Use this for initialization
	void Start () {
		if(bulb_row_controller == null)
        {
            bulb_row_controller = this;
        }
	}

    private void Reset_Bulbs()
    {
        for(int i=  0; i < bulb_controllers.Length; i++)
        {
            bulb_controllers[i].Dim_Bulb();
        }
    }

    public void Light_Bulbs(int _num_to_light, bool _light)
    {
        Reset_Bulbs();
        for(int i = 0; i < _num_to_light; i++)
        {
            Light_Bulb(i, _light);
        }
    }

    void Light_Bulb(int _bulb_num, bool _light)
    {
        if(_bulb_num < bulb_controllers.Length)
        {
            if (_light == true)
            {
                bulb_controllers[_bulb_num].Light_Bulb();
            }
            else
            {
                bulb_controllers[_bulb_num].Dim_Bulb();
            }
        }
    }
    
    public void Staggered_Light(int _num_to_light, float _delay, bool _light)
    {
        StartCoroutine(Light_Bulbs_Delay(_num_to_light, _delay, _light));
    }

    IEnumerator Light_Bulbs_Delay(int _num_to_light, float _delay, bool _light)
    {
        for(int i = 0; i < _num_to_light; i++)
        {
            Light_Bulb(i, _light);
            yield return new WaitForSeconds(_delay);
        }
    }
}
