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
    public bool broken, unplugged, bustFuze, switched;
    private JointSpring hinge;

    void Start()
    {
        hinge = lid.GetComponent<HingeJoint>().spring;
    }

    void FixedUpdate()
    {
        if(broken)
        {
            if(!unplugged && !bustFuze && !switched)
            {
                broken = false;
                foreach (var col in gameObject.GetComponentsInChildren<Collider>())
                {
                    col.enabled = true;
                }
                hinge.targetPosition = 0;
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
            hinge.targetPosition = 160;
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
}
