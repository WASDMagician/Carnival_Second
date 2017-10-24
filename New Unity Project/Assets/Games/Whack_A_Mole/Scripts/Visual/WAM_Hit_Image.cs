using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WAM_Hit_Image : MonoBehaviour
{
    public static WAM_Hit_Image hit_image;
    public float image_up_time;
    public SpriteRenderer hit_renderer;

    private void Start()
    {
        if (hit_image == null)
        {
            hit_image = this;
        }
    }

    public void Activate()
    {
        if (hit_renderer != null)
        {
            Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            position.z = 0;
            this.transform.position = position;
            hit_renderer.enabled = true;
            StartCoroutine(Deactivate_Image());
        }
        else
        {
            Debug.Log("WAM: hit renderer not found.");
        }
    }

    IEnumerator Deactivate_Image()
    {
        yield return new WaitForSeconds(image_up_time);
        if (hit_renderer != null)
        {
            hit_renderer.enabled = false;
        }
        else
        {
            Debug.Log("WAM: hit renderer not found.");
        }
    }
}
