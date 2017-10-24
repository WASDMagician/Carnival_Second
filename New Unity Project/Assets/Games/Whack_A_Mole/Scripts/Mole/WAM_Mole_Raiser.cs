using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WAM_Mole_Raiser : MonoBehaviour
{
    Collider2D mole_collider;
    Vector3 lowered_position, raised_position;
    public float raise_amount, raise_speed, wait_time, drop_speed;

    private void Start()
    {
        mole_collider = GetComponent<Collider2D>();
        if(mole_collider != null)
        {
            mole_collider.enabled = false;
        }
        lowered_position = this.transform.position;
        raised_position = this.transform.position;
        raised_position.y += raise_amount;
    }

    public void Set_Raise_Speed(float _raise_speed)
    {
        raise_speed = _raise_speed;
    }

    public void Set_Wait_Time(float _wait_time)
    {
        wait_time = _wait_time;
    }

    public void Set_Drop_Speed(float _drop_speed)
    {
        drop_speed = _drop_speed;
    }

    public void Set_Movement_Values(float _raise_speed, float _wait_time, float _drop_speed)
    {
        raise_speed = _raise_speed;
        wait_time = _wait_time;
        drop_speed = _drop_speed;
    }

    public void Activate()
    {
        StartCoroutine(Raise());
    }

    IEnumerator Raise()
    {
        while (this.transform.position != raised_position)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, raised_position, raise_speed * Time.deltaTime);
            yield return new WaitForSeconds(0);
        }
        this.transform.position = raised_position;

        mole_collider.enabled = true;

        SendMessage("On_Mole_Raise");

        yield return new WaitForSeconds(wait_time);

        StartCoroutine(Lower());
    }

    IEnumerator Lower()
    {
        SendMessage("On_Mole_Fall");
        mole_collider.enabled = false;
        while (this.transform.position != lowered_position)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, lowered_position, raise_speed * Time.deltaTime);
            yield return new WaitForSeconds(0);
        }
    }

    public IEnumerator Lower_Drop()
    {
        StopAllCoroutines();
        SendMessage("On_Mole_Fall");
        mole_collider.enabled = false;
        while (this.transform.position != lowered_position)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, lowered_position, drop_speed * Time.deltaTime);
            yield return new WaitForSeconds(0);
        }
    }
}
