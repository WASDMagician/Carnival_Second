using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WAM_Bulb_Controller : MonoBehaviour {

    bool is_lit;
    public SpriteRenderer lit_bulb, unlit_bulb;

    public void Light_Bulb()
    {
        lit_bulb.enabled = true;
        unlit_bulb.enabled = false;
    }

    public void Dim_Bulb()
    {
        unlit_bulb.enabled = true;
        lit_bulb.enabled = false;
    }

    public bool Bulb_Lit()
    {
        return is_lit;
    }
}
