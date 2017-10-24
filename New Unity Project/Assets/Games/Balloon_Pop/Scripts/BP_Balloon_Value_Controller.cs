using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BP_Balloon_Value_Controller : MonoBehaviour {

    int value;
    public SpriteRenderer single_digit, double_digit_first, double_digit_second;
    public Color sprite_color;
    public string path;

    public void Set_Value(int _value)
    {
        value = _value;
        if(_value < -9 || _value > 9)
        {
            Set_Double(_value);
        }
        else
        {
            Set_Single(_value);
        }
    }

    void Set_Single(int _value)
    {
        Display_Double(false);
        Display_Single(true);

        single_digit.sprite = Load_Sprite(_value.ToString()[0]);
        single_digit.color = sprite_color;
    }

    void Set_Double(int _value)
    {
        Display_Single(false);
        Display_Double(true);

        double_digit_first.sprite = Load_Sprite(_value.ToString()[0]);
        double_digit_first.color = sprite_color;

        double_digit_second.sprite = Load_Sprite(_value.ToString()[1]);
        double_digit_second.color = sprite_color;
    }

    void Display_Single(bool _display)
    {
        single_digit.enabled = _display;
    }

    void Display_Double(bool _display)
    {
        double_digit_first.enabled = _display;
        double_digit_second.enabled = _display;
    }

    Sprite Load_Sprite(char _name)
    {
        return Resources.Load<Sprite>(path + "" + _name);
    }

    public int Get_Value()
    {
        return value;
    }
}
