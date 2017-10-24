using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BP_Balloon_Controller : MonoBehaviour {

    BP_Balloon_Value_Controller value_controller;

    private void Start()
    {
        value_controller = GetComponent<BP_Balloon_Value_Controller>();
    }

    public void Set_Value(int _value)
    {
        if(value_controller == null)
        {
            value_controller = GetComponent<BP_Balloon_Value_Controller>();
        }
        if (value_controller != null)
        {
            value_controller.Set_Value(_value);
        }
    }
}
