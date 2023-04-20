using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    public MachineController machineCon;
    public SwitchBehavior switch1, switch2, switch3;
    private int rand;
    private bool flipped;


    void FixedUpdate()
    {
        if(machineCon.broken && flipped)
        {
            if(switch1.on && switch2.on && switch3.on)
            {
                flipped = false;
                machineCon.switched = false;
            }
        }
    }

    public void RandFlip()
    {
        rand = Random.Range(0, 2);
        if(rand == 0)
        {
            switch1.Flip();
        }
        rand = Random.Range(0, 2);
        if (rand == 0)
        {
            switch2.Flip();
        }
        rand = Random.Range(0, 2);
        if (rand == 0)
        {
            switch3.Flip();
        }
        flipped = true;
    }
}
