using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RB_Game_Controller : Game_Controller {

    public static RB_Game_Controller game_controller;
    public GameObject board;
    RB_Board_Loader board_loader;
    RB_Answer_Controller answer_controller;
    RB_Number_Tile[] number_tiles;
    RB_Answer_Tile answer_tile;
    RB_Difficulty_Controller difficulty_controller;
    RB_Ball ball;
    UI_Question_Display ui_question;
    int l = 0;
    int score = 0;

    private int answer;
    private int[] possible_answers;
	// Use this for initialization
	void Start () {
        if(game_controller == null)
        {
            game_controller = this;
        }
        ball = GameObject.FindObjectOfType<RB_Ball>();
        board_loader = GameObject.FindObjectOfType<RB_Board_Loader>();
        answer_controller = GetComponent<RB_Answer_Controller>();
        difficulty_controller = GetComponent<RB_Difficulty_Controller>();
        answer_tile = GameObject.FindObjectOfType<RB_Answer_Tile>();
        ui_question = UI_Question_Display.ui_question_display;
        Set_Board();
	}

    public void Reset_Board_Rotation()
    {
        board.transform.rotation = Quaternion.Euler(Vector3.zero);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F1))
        {
            Screen_Shotter.Take_Screen_Shot(l.ToString());
            l++;
        }
        if(Input.GetKeyDown(KeyCode.F2))
        {
            difficulty_controller.Increment_Level();
            Set_Board();
        }
    }

    void Set_Board()
    {
        //generate board
        Reset_Board_Rotation();
        board_loader.Generate_Board();
        number_tiles = FindObjectsOfType<RB_Number_Tile>();
        answer_tile = FindObjectOfType<RB_Answer_Tile>();
        
        //generate answer
        answer = answer_controller.Generate_Answer(true);
        if (ui_question == null)
        {
            ui_question = UI_Question_Display.ui_question_display;
        }
        if (ui_question != null)
        {
            string question_string = answer_controller.Get_Question();
            ui_question.Set_Question("");
            ui_question.Set_Question(question_string);
        }
        else
        {
            print("UI Question not found.");
        }
        possible_answers = answer_controller.Get_Possible_Answers(number_tiles.Length);
        for(int i = 0; i < number_tiles.Length; i++)
        {
            int chosen_answer = possible_answers[i];
            while(chosen_answer == answer)
            {
                chosen_answer = possible_answers[Random.Range(0, possible_answers.Length)];
            }
            number_tiles[i].Set_Tile_Value(chosen_answer);
        }
        ball.Respawn();
        Set_Answer();
    }

    public void Check_Answer(int _answer)
    {
        if(_answer == answer)
        {
            Answer_Hit();
        }
    }

    public void Answer_Hit()
    {
        if(difficulty_controller.Can_Increment_Level() == true)
        {
            score++;
            difficulty_controller.Increment_Level();
            Set_Board();
        }
    }

    void Set_Answer()
    {
        
        /*bool answer_is_contained = false;
        for(int i = 0; i < number_tiles.Length; i++)
        {
            if(number_tiles[i].Get_Tile_Value() == answer)
            {
                UnityEditor.Selection.activeObject = number_tiles[i].gameObject;
                answer_is_contained = true;
            }
        }
        if(answer_is_contained == false)
        {
            print("SET ANSWER");
            number_tiles[Random.Range(0, number_tiles.Length)].Set_Tile_Value(answer);
        }*/
        if(answer_tile == null)
        {
            answer_tile = GameObject.FindObjectOfType<RB_Answer_Tile>();
        }
        if(answer_tile != null)
        {
            answer_tile.Set_Tile_Value(answer);
        }
        else
        {
            Debug.Log("RB: Cannot find answer tile.");
        }
    }
}
