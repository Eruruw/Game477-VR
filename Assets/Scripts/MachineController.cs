using System;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MachineController : MonoBehaviour
{
    public GameObject lid, trigger, buttonObj;
    public SwitchController switches;
    public PlugBehavior plug;
    public HingeJoint hinge;
    public bool broken, unplugged, bustFuze, switched;
    private JointSpring hingeSpring;
    private XRGrabInteractable button;
    public tutorialArrow tutorial;
    public GameObject[] arrows;

    void Start()
    {
        button = buttonObj.GetComponent<XRGrabInteractable>();
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
                foreach (GameObject arrow in arrows)
                {
                    arrow.SetActive(false);
                }
            }
        }
    }

    public async void MakeShake()
    {
        if(!broken)
        {
            if (tutorial.currentStep == 32)
            {
                tutorial.incrementStep(32);
            }

            trigger.SetActive(true);
            await Task.Delay(200);
            trigger.SetActive(false);
            if (tutorial.currentStep == 33)
            {
                tutorial.incrementStep(33);
            }
            Game.globalInstance.sndPlayer.PlaySound(SoundType.ITEM_COMPLETE, GetComponent<AudioSource>());
        }
    }

    public void MachineBreak()
    {
        int rand = UnityEngine.Random.Range(0, 5);
        if (rand == 0)
        {
            button.enabled = false;
            foreach(var col in lid.GetComponentsInChildren<Collider>())
            {
                col.enabled = false;
            }
            hingeSpring.targetPosition = 130;
            hinge.spring = hingeSpring;
            int rand2 = UnityEngine.Random.Range(0, 3);
            for (int i = 0; i < rand2; i++)
            {
                int rand3 = UnityEngine.Random.Range(0, 3);
                if (rand3 == 0)
                {
                    plug.SlipOut();
                    unplugged = true;
                    arrows[2].SetActive(true);
                }
                else if (rand3 == 1)
                {
                    bustFuze = true;
                    arrows[0].SetActive(true);
                    arrows[1].SetActive(true);
                }
                else if (rand3 == 2)
                {
                    switches.RandFlip();
                    switched = true;
                    arrows[3].SetActive(true);
                }
            }
            broken = true;
        }
    }

    private async void EnableCols()
    {
        await Task.Delay(4000);
        foreach (var col in lid.GetComponentsInChildren<Collider>())
        {
            col.enabled = true;
        }
        button.enabled = true;
    }
}
