using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Num_Value_Controller : MonoBehaviour {

    public string path;
    public GameObject display_board;
    public SpriteRenderer single_digit_sign, single_digit, double_digit_sign, double_digit_first, double_digit_second;
    public bool include_sign;
    protected float value;

	public virtual void Set_Value(int _value)
    {
        value = _value;
        string str_val = Int_To_String_With_Sign(_value);

        if (_value >= 10 || _value <= -10)
        {   
            //set double digit values
            if(include_sign == true)
            {
                double_digit_sign.sprite = Load_Sprite(str_val[0]);
            }
            double_digit_first.sprite = Load_Sprite(str_val[1]);
            double_digit_second.sprite = Load_Sprite(str_val[2]);
            
            Set_Visible(true, false, true);
        }
        else
        {
            //set single digit values
            Set_Visible(true, true, false);
            if(include_sign == true)
            {
                single_digit_sign.sprite = Load_Sprite(str_val[0]);
            }
            single_digit.sprite = Load_Sprite(str_val[1]);
        }
    }

    public virtual void Set_Visible(bool _display_board, bool _single_digit, bool _double_digit)
    {
        if (display_board != null && single_digit_sign != null && single_digit != null && double_digit_sign != null && double_digit_first != null && double_digit_second != null)
        {
            display_board.SetActive(_display_board);
            if (include_sign == true)
            {
                single_digit_sign.enabled = _single_digit;
                double_digit_sign.enabled = _double_digit;
            }
            single_digit.enabled = _single_digit;
            double_digit_first.enabled = _double_digit;
            double_digit_second.enabled = _double_digit;
        }
        else
        {
            Debug.Log("Display board or sprite renderer missing.");
        }

    }

    public virtual void Hide_Board()
    {
        if(display_board != null)
        {
            display_board.SetActive(false);
        }
        else
        {
            Debug.Log("Display board not found.");
        }
    }

    public virtual Sprite Load_Sprite(char _sprite_name)
    {
        return Resources.Load<Sprite>(path + "" + _sprite_name);
    }

    public virtual float Get_Value()
    {
        return value;
    }

    //add "+" to any value of 0 or above.
    public virtual string Int_To_String_With_Sign(int _value)
    {
        string str_val = _value.ToString();
        if (_value >= 0)
        {
            str_val = str_val.Insert(0, "+");
        }
        return str_val;
    }
}
