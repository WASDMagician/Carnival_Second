using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load_Level : MonoBehaviour {

    public string level_name;

    public void Load()
    {
        if (level_name != "")
        {
            SceneManager.LoadScene(level_name);
        }
        else
        {
            Debug.Log("Incorrect level name.");
        }
    }
}
