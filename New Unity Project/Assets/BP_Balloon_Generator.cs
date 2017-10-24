using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BP_Balloon_Generator : MonoBehaviour {

    public GameObject[] balloon_prefabs;
    public Transform[] balloon_positions;
    List<BP_Balloon_Controller> spawned_balloons = new List<BP_Balloon_Controller>();


    public void Generate_Balloons(int[] values)
    {
        Destroy_Balloons();
        for(int i = 0; i < values.Length; i++)
        {
            GameObject balloon = Instantiate(balloon_prefabs[Random.Range(0, balloon_prefabs.Length - 1)], balloon_positions[i].transform.position, Quaternion.identity) as GameObject;
            BP_Balloon_Controller controller = balloon.GetComponent<BP_Balloon_Controller>();
            spawned_balloons.Add(controller);
            controller.Set_Value(values[i]);
        }
    }

    public void Set_Answer(int _answer)
    {
        spawned_balloons[Random.Range(0, spawned_balloons.Count)].Set_Value(_answer);
    }

    void Destroy_Balloons()
    {
        foreach(BP_Balloon_Controller balloon in spawned_balloons)
        {
            Destroy(balloon.gameObject);
        }
        spawned_balloons.Clear();
    }
}
