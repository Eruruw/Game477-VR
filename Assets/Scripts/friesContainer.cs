using System.Collections;
using System.Collections.Generic;
using Unity.Tutorials.Core.Editor;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class friesContainer : MonoBehaviour
{
    public GameObject scoopFries;
    public GameObject containerFries;
    public bool canFill;
    public tutorialArrow tutorial;


    // Start is called before the first frame update
    void Start()
    {
        canFill = true;
    }

    private void OnTriggerEnter(Collider c)
    {
        if (c.CompareTag("fullScoop") && canFill)
        {
            scoopFries.SetActive(false);
            containerFries.SetActive(true);
            canFill = false;
            c.gameObject.tag = "emptyScoop";
            gameObject.tag = "fries";

            if (tutorial.currentStep == 28)
            {
                tutorial.incrementStep(28);
            }
        }


    }

    public void incrementIfNext(SelectEnterEventArgs args)
    {
        if (args.interactorObject.transform.CompareTag("Player"))
        {
            if (tutorial.currentStep == 27)
            {
                tutorial.incrementStep(27);
            }
        }
    }
}
