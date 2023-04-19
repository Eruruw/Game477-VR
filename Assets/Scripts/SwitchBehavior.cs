using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchBehavior : MonoBehaviour
{
    public SwitchController switchCon;
    public bool on = true;

    public void Flip()
    {
        if (on)
        {
            on = false;
            transform.position = new Vector3(transform.position.x, -transform.position.y, transform.position.z);
        }
        else
        {
            on = true;
            transform.position = new Vector3(transform.position.x, -transform.position.y, transform.position.z);
        }
    }
}
