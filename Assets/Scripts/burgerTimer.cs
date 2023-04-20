using System.Collections;
using System.Collections.Generic;
using Unity.Tutorials.Core.Editor;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class burgerTimer : MonoBehaviour
{
    public bool cooking = false;
    public float timer;
    public float cookTime = 30;
    private IngredientController IC;
    public tutorialArrow tutorial;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        IC = GetComponent<IngredientController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cooking)
        {
            timer += Time.deltaTime;
            if (timer > cookTime)
            {
                gameObject.tag = "cookedPatty";
                IC.foodVal = 10000;

                if (tutorial.currentStep == 5)
                {
                    tutorial.incrementStep(5);
                }

                //insert code to change patty model to cooked here
            }
            if (timer > 450)
            {
                gameObject.tag = "overcookedPatty";
                IC.foodVal = 0;
                //insert code to change patty model to overcooked here
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("griddle"))
        {
            Game.globalInstance.sndPlayer.PlaySound(SoundType.BURGER_COOK, GetComponent<AudioSource>());
            cooking = true;
            if (tutorial.currentStep == 4)
            {
                tutorial.incrementStep(4);
            }
        }
        if (collision.gameObject.CompareTag("prep"))
        {
            if (tutorial.currentStep == 7)
            {
                tutorial.incrementStep(7);
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("griddle"))
        {
            Game.globalInstance.sndPlayer.PlaySound(SoundType.ITEM_COMPLETE, GetComponent<AudioSource>());
            cooking = false;
            if (tutorial.currentStep == 6)
            {
                tutorial.incrementStep(6);
            }
        }
    }

    public void incrementIfPatty(SelectEnterEventArgs args)
    {
        if (args.interactorObject.transform.CompareTag("Player"))
        {
            if (tutorial.currentStep == 10)
            {
                tutorial.incrementStep(10);
            }
        }
    }
}
