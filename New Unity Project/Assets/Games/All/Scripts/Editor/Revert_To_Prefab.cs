using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Revert_To_Prefab : MonoBehaviour {

    [MenuItem("Tools/Prefabs/Revert all to prefab.")]
	public static void Revert_All_To_Prefab()
    {
        GameObject[] prefabs = Selection.gameObjects;
        for(int i = 0; i < prefabs.Length; i++)
        {
            PrefabUtility.RevertPrefabInstance(prefabs[i]);
        }
    }
}
