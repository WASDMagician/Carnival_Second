using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debug_Lighter : MonoBehaviour {
    MeshRenderer board_renderer;
    public Material unlit, lit;
	// Use this for initialization
	void Start () {
        board_renderer = GetComponent<MeshRenderer>();
        StartCoroutine(Switch());
	}

    IEnumerator Switch()
    {
        board_renderer.material = unlit;
        yield return new WaitForSeconds(0.5f);
        board_renderer.material = lit;
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(Switch());
    }
}
