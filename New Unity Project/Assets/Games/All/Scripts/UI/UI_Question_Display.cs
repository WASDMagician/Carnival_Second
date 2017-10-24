using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Question_Display : MonoBehaviour {

    public Text question_text;

    public static UI_Question_Display ui_question_display;

    private void Start()
    {
        if(ui_question_display == null)
        {
            ui_question_display = this;
        }
    }

    public void Set_Question(string _question)
    {
        if (question_text != null)
        {
            question_text.text = _question;
        }
        else
        {
            Debug.Log("Question text not found.");
        }
    }
}
