using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Count : MonoBehaviour {
    [MenuItem("Tools/Misc/Count_Selected")]
	public static void Print_Count()
    {
        Debug.Log(Selection.gameObjects.Length);
    }
}
