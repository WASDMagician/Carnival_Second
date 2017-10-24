using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Difficulty_Controller))]
[RequireComponent(typeof(Question_Generator))]
public class BP_Game_Controller : MonoBehaviour {

    public static BP_Game_Controller game_controller;
    BP_Difficulty_Controller difficulty_controller;
    Question_Generator question_generator;
    UI_Question_Display ui_question_display;
    BP_Balloon_Generator balloon_generator;

	// Use this for initialization
	void Start () {
        if(game_controller == null)
        {
            game_controller = this;
        }
        difficulty_controller = GetComponent<BP_Difficulty_Controller>();
        question_generator = GetComponent<Question_Generator>();
        balloon_generator = GetComponent<BP_Balloon_Generator>();
        ui_question_display = UI_Question_Display.ui_question_display;
        Play();
	}    

    void Play()
    {
        question_generator.Generate_Question(difficulty_controller);
        ui_question_display.Set_Question(question_generator.Get_Question());
        question_generator.Generate_Possible_Answers(difficulty_controller);
        balloon_generator.Generate_Balloons(question_generator.Get_Possible_Answers().ToArray());
        balloon_generator.Set_Answer(question_generator.Get_Answer());
    }

    public void Answer_Check(int _answer)
    {
        if(_answer == question_generator.Get_Answer())
        {
            difficulty_controller.Increment_Level();
            Play();
        }
        else
        {
            difficulty_controller.Decrement_Level();
        }
    }

}
