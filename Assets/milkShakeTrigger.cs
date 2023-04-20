using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class milkShakeTrigger : MonoBehaviour
{
    public tutorialArrow tutorial;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("milkMachine"))
        {
            if (tutorial.currentStep == 31)
            {
                tutorial.incrementStep(31);
            }
        }
    }
}
