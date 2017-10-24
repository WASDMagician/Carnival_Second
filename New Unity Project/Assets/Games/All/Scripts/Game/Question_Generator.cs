using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Question_Generator : MonoBehaviour {

    private int answer;
    private string question;
    private List<int> question_components = new List<int>();
    private List<int> possible_answers = new List<int>();

    public void Generate_Question(Difficulty_Controller _difficulty_controller)
    {
        if (_difficulty_controller != null)
        {
            //generate question and answer
            answer = 0;
            string _question = "";
            for (int i = 0; i < _difficulty_controller.Get_Digits_To_Use(); i++)
            {
                int digit = Random.Range(_difficulty_controller.Get_Min_Num_To_Use(), _difficulty_controller.Get_Max_Num_To_Use());
                _question += digit.ToString();
                question_components.Add(digit);
                _question += " + ";
                answer += digit;
            }
            question = _question.Substring(0, _question.Length - 2);
        }
        else
        {
            Debug.Log("Passed difficulty controller is null.");
        }
    }

    public void Generate_Possible_Answers(BP_Difficulty_Controller _difficulty_controller)
    {
        possible_answers.Clear();
        for(int i=  0; i < _difficulty_controller.Get_Balloons_To_use(); i++)
        {
            int possible_answer = 0;
            while(possible_answer == 0 || possible_answer == answer)
            {
                possible_answer = Random.Range(0, 3) % 2 == 0 ? Random.Range((answer - (int)answer / 2), answer - 1) : Random.Range(answer + 1, answer * 2);                
            }
            possible_answers.Add(possible_answer);
        }
    }

    public List<int> Get_Question_Components()
    {
        return question_components;
    }

    public int Get_Answer()
    {
        return answer;
    }

    public string Get_Question()
    {
        return question;
    }

    public List<int> Get_Possible_Answers()
    {
        return possible_answers;
    }
}
