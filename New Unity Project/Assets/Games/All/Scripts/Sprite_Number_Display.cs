using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprite_Number_Display : MonoBehaviour {

    public SpriteRenderer board_sprite, sign_single, sign_double, digit_single, digit_double_first, digit_double_second;
    public bool allow_sign;
    public string number_path;

    private void Start()
    {
        Set_Value(15, true);
    }

    public void Set_Value(int _value, bool _show_board)
    {
        if(_show_board == true)
        {
            board_sprite.enabled = true;
        }
        else
        {
            board_sprite.enabled = false;
        }

        if(_value > 9 || _value < -9)
        {
            Show_Double();
            Set_Double_Value(_value);
            
        }
        else
        {
            Show_Single();
            Set_Single_Value(_value);
        }
    }

    void Set_Double_Value(int _value)
    {
        Sprite digit_one = Load_Sprite(_value.ToString()[0]);
        Sprite digit_two = Load_Sprite(_value.ToString()[1]);
        digit_double_first.sprite = digit_one;
        digit_double_second.sprite = digit_two;
    }

    void Set_Single_Value(int _value)
    {

    }
    
    public void Show_Single()
    {
        Hide_Double();
        sign_single.enabled = true;
        digit_single.enabled = true;
    }

    public void Hide_Single()
    {
        sign_single.enabled = false;
        digit_single.enabled = false;
    }

    public void Show_Double()
    {
        Hide_Single();
        sign_double.enabled = true;
        digit_double_first.enabled = true;
        digit_double_second.enabled = true;
    }

    public void Hide_Double()
    {
        sign_double.enabled = false;
        digit_double_first.enabled = false;
        digit_double_second.enabled = false;
    }

    Sprite Load_Sprite(char _character)
    {
        return Resources.Load<Sprite>(number_path + _character);
    }
}
