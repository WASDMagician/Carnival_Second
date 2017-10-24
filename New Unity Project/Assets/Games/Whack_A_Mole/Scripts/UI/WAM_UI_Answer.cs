using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WAM_UI_Answer : MonoBehaviour {

    public static WAM_UI_Answer ui_answer;

    public Text question_text;
    public Text answer_text;

	// Use this for initialization
	void Start () {
		if(ui_answer == null)
        {
            ui_answer = this;
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
            Debug.Log("WAM: Question text is null.");
        }
    }

    public void Set_Answer(string _answer)
    {
        if(answer_text != null)
        {
            answer_text.text = _answer;
        }
        else
        {
            Debug.Log("WAM: Answer text is null.");
        }
    }
}
