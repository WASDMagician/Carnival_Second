using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WAM_Answer_Controller : Answer_Controller {
    public static WAM_Answer_Controller answer_controller;
    WAM_Difficulty_Controller difficulty_controller;
    WAM_UI_Answer ui_answer;
    WAM_Bulb_Row_Controller bulb_row_controller;
    WAM_UI_Score_Controller ui_score_controller;
    private string question;
    private int answer, given_answer, incorrect_spree, correct_spree, score;
    public int max_score, ticket_1_score, ticket_2_score, ticket_3_score, point_value;

	// Use this for initialization
	void Start () {
        if(answer_controller == null)
        {
            answer_controller = this;
        }

		if(WAM_Difficulty_Controller.difficulty_controller != null)
        {
            difficulty_controller = WAM_Difficulty_Controller.difficulty_controller;
            Generate_Answer();
        }
        else
        {
            Debug.Log("WAM: Difficulty controller not found.");
        }

        if(WAM_UI_Answer.ui_answer)
        {
            ui_answer = WAM_UI_Answer.ui_answer;
        }
        else
        {
            Debug.Log("WAM: UI answer not found.");
        }

        if(WAM_UI_Score_Controller.ui_score_controller != null)
        {
            ui_score_controller = WAM_UI_Score_Controller.ui_score_controller;
        }
        else
        {
            Debug.Log("WAM: UI Score controller not found");
        }

        if(WAM_Bulb_Row_Controller.bulb_row_controller != null)
        {
            bulb_row_controller = WAM_Bulb_Row_Controller.bulb_row_controller;
        }
        else
        {
            Debug.Log("WAM: Bulb row controller not found");
        }
	}
	
	void Generate_Answer()
    {
        if(difficulty_controller != null)
        {
            Vector2 range = difficulty_controller.Get_Min_Max_Answer();
            int digit_one = (int)Random.Range(range.x, range.y);
            int digit_two = (int)Random.Range(range.x, range.y);
            question = digit_one.ToString() + " + " + digit_two.ToString();
            answer = digit_one + digit_two;
            Set_UI();
        }
        else
        {
            Debug.Log("WAM: Difficulty controller not found.");
        }
    }

    void Set_UI()
    {
        if(ui_answer == null)
        {
            ui_answer = WAM_UI_Answer.ui_answer;
        }
        if(ui_answer != null)
        {
            ui_answer.Set_Question(question);
        }
        else
        {
            Debug.Log("WAM: UI answer not found.");
        }
    }



    public void Add_To_Answer(int _amount)
    {
        given_answer += _amount;
        Set_UI_Answer();
    }
    
    public void Check_Answer()
    {
        if(Answered_Correctly() == true)
        {
            score += point_value * (difficulty_controller.Get_Difficulty_Level() + 1);
            correct_spree++;
            incorrect_spree = 0;
            if (correct_spree == difficulty_controller.Get_Level_Increase_Requirement())
            {
                difficulty_controller.Increase_Difficulty();
                bulb_row_controller.Light_Bulbs(difficulty_controller.Get_Difficulty_Level(), true);
                correct_spree = 0;
            }
            Update_Score();
            Reset();
        }
        else
        {
            incorrect_spree++;
            print(difficulty_controller.Get_Level_Decrease_Requirement());
            if(incorrect_spree == difficulty_controller.Get_Level_Decrease_Requirement())
            {
                difficulty_controller.Decrease_Difficulty();
                bulb_row_controller.Light_Bulbs(difficulty_controller.Get_Difficulty_Level(), true);
                incorrect_spree = 0;
            }
            correct_spree = 0;
        }
    }

    void Update_Score()
    {
        if (ui_score_controller != null && difficulty_controller != null)
        {
            print(score);
            ui_score_controller.Update_Score_Display(ticket_1_score, ticket_2_score, ticket_3_score, score, max_score);
        }
        else
        {
            if (ui_score_controller == null)
            {
                Debug.Log("WAM: UI score controller not found.");
            }
            if (difficulty_controller == null)
            {
                Debug.Log("WAM: Difficulty controller not found.");
            }
        }
    }

    private void Reset()
    {
        Generate_Answer();
        given_answer = 0;
        Set_UI_Answer();
    }

    bool Answered_Correctly()
    {
        return given_answer == answer;
    }

    void Set_UI_Answer()
    {
        if(ui_answer != null)
        {
            ui_answer.Set_Answer(given_answer.ToString());
        }
        else
        {
            Debug.Log("WAM: UI awnser not found.");
        }
    }
}
