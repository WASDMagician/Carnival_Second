using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WAM_Difficulty_Controller : Difficulty_Controller {

    public static WAM_Difficulty_Controller difficulty_controller;

    [Header("See tooltips for more information.")]
    [Header("Difficulty level slider.")]
    [Tooltip("Come on now, this doesn't need more information, give it a think.")]
    [Range(0, 9)]
    private int difficulty_level = 0;

    [Header("Difficulty curves.")]
    [Tooltip("Controls how long the mole stays up for, should get shorter at higher difficulties, each value should sit on an int between 0 and 9, the curve itself doesn't matter.")]
    public AnimationCurve mole_raised_time;

    [Tooltip("Controls how much time passes, should get longer at higher difficulties, each value should site on an int between 0 and 9, the curve itself doesn't matter. ")]
    public AnimationCurve raise_mole_wait_time;

    [Tooltip("How many questions you need to answer correctly to go up a level based on current level")]
    public AnimationCurve level_increase_curve;

    [Tooltip("How many questions you need to answer correctly to go down a level based on current level")]
    public AnimationCurve level_decrease_curve;

    [Header("The lowest and highest number to display at difficulty levels.")]
    [Tooltip("Sets the minimum and maximum number per difficulty level.")]
    public Vector2[] min_max_addition;

    [Header("The highest answer to allow.")]
    [Tooltip("Sets the largest answer to be allowed.")]
    public Vector2[] min_max_answers;

	// Use this for initialization
	void Start () {
		if(difficulty_controller == null)
        {
            difficulty_controller = this;
        }
	}

    public void Increase_Difficulty()
    {
        if(difficulty_level < 9) //9 is arbitrary cutoff
        {
            difficulty_level++;
        }
    }

    public void Decrease_Difficulty()
    {
        if(difficulty_level > 0)
        {
            difficulty_level--;
        }
    }

    public float Get_Mole_Raise_Time()
    {
        return mole_raised_time.Evaluate(difficulty_level);
    }

    public float Get_Mole_Wait_Time()
    {
        return raise_mole_wait_time.Evaluate(difficulty_level);
    }

    public Vector2 Get_Min_And_Max_Addition()
    {
        return min_max_addition[difficulty_level];
    }

    public int Get_Addition()
    {
        Vector2 range = min_max_addition[difficulty_level];
        int num = (int)Random.Range(range.x, range.y);
        while(num == 0)
        {
            num = (int)Random.Range(range.x, range.y);
        }
        return num;
    }

    public Vector2 Get_Min_Max_Answer()
    {
        return min_max_answers[difficulty_level];
    }

    public int Get_Answer()
    {
        Vector2 range = min_max_answers[difficulty_level];
        return (int)Random.Range(range.x, range.y);
    }

    public int Get_Difficulty_Level()
    {
        return difficulty_level;
    }

    public int Get_Level_Increase_Requirement()
    {
        return (int)level_increase_curve.Evaluate(difficulty_level);
    }

    public int Get_Level_Decrease_Requirement()
    {
        return (int)level_decrease_curve.Evaluate(difficulty_level);
    }
}
