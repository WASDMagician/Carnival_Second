using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RB_Answer_Controller : Answer_Controller {

    RB_Difficulty_Controller difficulty_controller;
    private string question = "";

    private void Start()
    {
        difficulty_controller = GetComponent<RB_Difficulty_Controller>();
    }

    //generate possible answers
    public int[] Get_Possible_Answers(int _num_answers)
    {
        int[] possible_answers = new int[_num_answers]; //25 is magic num, must be higher than number tiles on board
        for(int i=  0; i < possible_answers.Length; i++)
        {
            possible_answers[i] = Generate_Answer(false);
        }
        return possible_answers;
    }

	public int Generate_Answer(bool _generate_question)
    {
        if(_generate_question == true)
        {
            question = "";
        }
        int possible_answer = 0;
        if (difficulty_controller != null)
        {
            for(int i = 0; i < difficulty_controller.Get_Num_Digits_To_Use(); i++)
            {
                int num = Random.Range(difficulty_controller.Get_Min_Num_To_Use(), difficulty_controller.Get_Max_Num_To_Use());
                if (_generate_question == true)
                {
                    question += num.ToString();
                    if(i != difficulty_controller.Get_Num_Digits_To_Use() - 1)
                    {
                        question += " + ";
                    }
                }
                possible_answer += num;
            }
            if (_generate_question == true)
            {
                question += " = " + possible_answer.ToString();
            }
        }
        else
        {
            Debug.Log("RB: difficulty controller not found");
        }
        return possible_answer;
    }

    public string Get_Question()
    {
        return question;
    }
}
