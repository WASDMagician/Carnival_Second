﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draw_Gizmos : MonoBehaviour {

    public bool draw_gizmos;
#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        if (draw_gizmos == true)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawCube(this.transform.position, Vector3.one);
        }
    }
#endif
}
