using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class refillPatties : MonoBehaviour
{
    public CloneSocketObject socket;
    public tutorialArrow tutorial;

    // Start is called before the first frame update
    void Start()
    {
        socket.numObjs = 5;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("burgerBag"))
        {
            socket.CloneInteractable();
            socket.numObjs = 0;
            if (tutorial.currentStep == 2)
            {
                tutorial.incrementStep(2);
            }
            Destroy(collision.gameObject);
        }
    }

    public void OnTriggerExit(Collider c)
    {
        print($"currentStep: {tutorial.currentStep}");
        if (c.gameObject.CompareTag("uncookedPatty"))
        {
            if (tutorial.currentStep == 3)
            {
                tutorial.incrementStep(3);
            }
        }
    }
}
