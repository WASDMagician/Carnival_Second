using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WAM_Mole_Sprite_Switcher : MonoBehaviour {

    public SpriteRenderer mole_renderer;
    public Sprite normal_sprite, hit_sprite;

	// Use this for initialization
	void Start () {
	}

    public void Set_Normal_Sprite()
    {
        if(mole_renderer != null && normal_sprite != null)
        {
            mole_renderer.sprite = normal_sprite;
        }
        else
        {
            if(mole_renderer == null)
            {
                Debug.Log("WAM: mole sprite renderer not found.");
            }
            else
            {
                Debug.Log("WAM: normal sprite not found.");
            }
        }
    }
	
	public void Set_Hit_Sprite()
    {
        if (mole_renderer != null && hit_sprite != null)
        {
            mole_renderer.sprite = hit_sprite;
        }
        else
        {
            if (mole_renderer == null)
            {
                Debug.Log("WAM: mole sprite renderer not found.");
            }
            else
            {
                Debug.Log("WAM: hit sprite not found.");
            }
        }
    }
}
