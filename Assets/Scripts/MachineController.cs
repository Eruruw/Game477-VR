using System;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineController : MonoBehaviour
{
    public GameObject lid, trigger;
    public SwitchController switches;
    public PlugBehavior plug;
    public HingeJoint hinge;
    public bool broken, unplugged, bustFuze, switched;
    private JointSpring hingeSpring;

    void Start()
    {
        hingeSpring = hinge.spring;
    }

    void FixedUpdate()
    {
        if (broken)
        {
            if (!unplugged && !bustFuze && !switched)
            {
                broken = false;
                hingeSpring.targetPosition = 0;
                hinge.spring = hingeSpring;
                EnableCols();
            }
        }
    }

    public async void MakeShake()
    {
        if(!broken)
        {
            trigger.SetActive(true);
            await Task.Delay(10);
            trigger.SetActive(false);
        }
    }

    public void MachineBreak()
    {
        int rand = UnityEngine.Random.Range(0, 5);
        if (rand == 0)
        {
            foreach(var col in lid.GetComponentsInChildren<Collider>())
            {
                col.enabled = false;
            }
            hingeSpring.targetPosition = 160;
            hinge.spring = hingeSpring;
            int rand2 = UnityEngine.Random.Range(0, 3);
            for (int i = 0; i < rand2; i++)
            {
                int rand3 = UnityEngine.Random.Range(0, 3);
                if (rand3 == 0)
                {
                    plug.SlipOut();
                    unplugged = true;
                }
                else if (rand3 == 1)
                {
                    bustFuze = true;
                }
                else if (rand3 == 2)
                {
                    switches.RandFlip();
                    switched = true;
                }
            }
            broken = true;
        }
    }

    private async void EnableCols()
    {
        await Task.Delay(500);
        foreach (var col in lid.GetComponentsInChildren<Collider>())
        {
            col.enabled = true;
        }
    }
}
