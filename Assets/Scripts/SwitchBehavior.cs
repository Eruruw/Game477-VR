using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchBehavior : MonoBehaviour
{
    public SwitchController switchCon;
    public bool on = true;
    private Vector3 startPos;
    private Vector3 negPos;

    void Start()
    {
        startPos = transform.localPosition;
        float yPos = transform.localPosition.y;
        float negY = -yPos;
        negPos = new Vector3(startPos.x, negY, startPos.z);
    }

    public void Flip()
    {
        if (on)
        {
            on = false;
            transform.localPosition = negPos;
        }
        else
        {
            on = true;
            transform.localPosition = startPos;
        }
    }
}
