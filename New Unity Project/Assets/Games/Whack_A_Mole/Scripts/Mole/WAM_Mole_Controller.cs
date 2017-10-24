using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WAM_Mole_Controller : MonoBehaviour {

    private WAM_Mole_Raiser mole_raiser;
    private Num_Value_Controller mole_value_controller;
    private WAM_Answer_Controller answer_controller;
    private WAM_Mole_Sprite_Switcher mole_sprite_switcher;
    private WAM_Hit_Image hit_image;
    private bool mole_raised = false;

	// Use this for initialization
	void Start () {
        mole_raiser = GetComponent<WAM_Mole_Raiser>();
        mole_value_controller = GetComponent<Num_Value_Controller>();
        mole_sprite_switcher = GetComponent<WAM_Mole_Sprite_Switcher>();
        hit_image = WAM_Hit_Image.hit_image;
        if (WAM_Answer_Controller.answer_controller != null)
        {
            answer_controller = WAM_Answer_Controller.answer_controller;
        }
	}
    
	
	// Update is called once per frame
	public void Activate_Mole(int _value)
    {
        if(mole_raiser != null && mole_value_controller != null)
        {
            mole_value_controller.Set_Value(_value);
            mole_raiser.Activate();
        }
        else
        {
            Debug.Log("WAM: Mole value controller and or mole raiser not found.");
        }
    }

    public void Activate_Mole(int _value, float _wait_time)
    {
        if(mole_raiser != null)
        {
            if(mole_sprite_switcher != null)
            {
                mole_sprite_switcher.Set_Normal_Sprite();
            }
            else
            {
                Debug.Log("WAM: Mole sprite switcher not found.");
            }
            mole_raiser.Set_Wait_Time(_wait_time);
            Activate_Mole(_value);
        }
    }

    public void Activate_Mole(int _value, float _raise_speed, float _wait_time, float _drop_speed)
    {
        if(mole_raiser != null)
        {
            if (mole_sprite_switcher != null)
            {
                mole_sprite_switcher.Set_Normal_Sprite();
            }
            else
            {
                Debug.Log("WAM: Mole sprite switcher not found.");
            }
            mole_raiser.Set_Movement_Values(_raise_speed, _wait_time, _drop_speed);
            Activate_Mole(_value);
        }
        else
        {
            Debug.Log("WAM: Mole raiser not found.");
        }
        
    }

    void On_Mole_Raise()
    {
        if (mole_value_controller != null)
        {
            mole_raised = true;
        }
        else
        {
            Debug.Log("WAM: Mole value controller not found");
        }

    }

    void On_Mole_Fall()
    {
        if (mole_value_controller != null)
        {
            mole_raised = false;
            mole_value_controller.Hide_Board();
        }
        else
        {
            Debug.Log("WAM: Mole value controller not found");
        }
    }

    public bool Get_Mole_Raised()
    {
        return mole_raised;
    }

    private void OnMouseDown()
    {
        if(hit_image == null)
        {
            if(WAM_Hit_Image.hit_image != null)
            {
                hit_image = WAM_Hit_Image.hit_image;
            }
        }
        if(hit_image != null)
        {
            hit_image.Activate();
        }
        else
        {
            Debug.Log("WAM: Hit image not found.");
        }

        if(mole_raiser != null && mole_raised == true && answer_controller != null && mole_value_controller != null && mole_sprite_switcher != null)
        {
            mole_sprite_switcher.Set_Hit_Sprite();
            answer_controller.Add_To_Answer((int)mole_value_controller.Get_Value());
            StartCoroutine(mole_raiser.Lower_Drop());
        }
        if(answer_controller == null)
        {
            Debug.Log("WAM: No answer controller found.");
        }
        if(mole_raiser == null)
        {
            Debug.Log("WAM: No mole raiser found.");
        }
        if(mole_value_controller == null)
        {
            Debug.Log("WAM: No mole value controller found.");
        }
        if(mole_sprite_switcher == null)
        {
            Debug.Log("WAM: No mole sprite switcher found.");
        }
    }
}
