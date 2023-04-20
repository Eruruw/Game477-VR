using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlugBehavior : MonoBehaviour
{
    public MachineController machineCon;
    public GameObject plugged;
    public GameObject unplugged;
    
    public void PlugIn()
    {
        machineCon.unplugged = false;
        plugged.SetActive(true);
        unplugged.SetActive(false);
    }

    public void SlipOut()
    {
        plugged.SetActive(false);
        unplugged.SetActive(true);
    }
}
