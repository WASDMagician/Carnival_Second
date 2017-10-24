using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WAM_UI_Score_Controller : MonoBehaviour {

    public static WAM_UI_Score_Controller ui_score_controller;

    public Image ticket_1, ticket_2, ticket_3;
    public Sprite ticket_unlit, ticket_lit;
    public Image background_image;
    int score;

	// Use this for initialization
	void Start () {
        if(ui_score_controller == null)
        {
            ui_score_controller = this;
        }
		if(background_image != null)
        {
            background_image.fillAmount = 0;
        }
	}
	
	public void Update_Score_Display(int _ticket_1, int _ticket_2, int _ticket_3, int _score, int _max_score)
    {
        if(_score >= _ticket_1)
        {
            Set_Image(ticket_1, ticket_lit);
        }
        if(_score >= _ticket_2)
        {
            Set_Image(ticket_2, ticket_lit);
        }
        if(_score >= _ticket_3)
        {
            Set_Image(ticket_3, ticket_lit);
        }

        if(background_image != null)
        {
            background_image.fillAmount = ((float)_score / (float)_max_score) / 10.0f;
        }
        else
        {
            Debug.Log("WAM: background image not set.");
        }
    }

    void Set_Image(Image _image, Sprite _sprite)
    {
        if(_image != null && _sprite != null)
        {
            _image.sprite = _sprite;
        }
        else
        {
            if(_image == null)
            {
                Debug.Log("WAM: ui score controller image not found.");
            }
            if(_sprite == null)
            {
                Debug.Log("WAM: ui score controller sprite not found.");
            }
        }
    }
}
