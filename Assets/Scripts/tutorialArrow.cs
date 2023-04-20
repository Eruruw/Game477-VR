using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Tutorials.Core.Editor;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class tutorialArrow : MonoBehaviour
{
    private string[] taskText;
    public Transform[] arrowPositions;
    public int currentStep;
    public TMP_Text arrowText;

    // Start is called before the first frame update
    void Start()
    {

        taskText = new string[] 
        {
            "Open the fridge",
            "Grab the bag of\nburger patties",
            "Refill the stack of patties by\nplacing the bag here",
           
            "Grab a patty",
            "Place the patty on\nthe griddle",
            "Wait for the burger to\nfinish cooking",
            "Take the buger off of\nthe griddle before it burns",
            "Bring the cooked patty\nover to the prep table",
           
           
            "Grab the bottom bun",
            "Place the bottom bun\non the tray",
            "Grab the cooked patty",
            "Place the cooked patty\non the bottom bun",
            "Grab the cheese",
            "Place the cheese\non the patty",
            "Grab the top bun",
            "Place the bun on\ntop of the cheese",
            "Grab the completed\nburger",
            "Place the burger\nin the paper bag",
           
           
            "Open the fridge",
            "Grab the bag of\nuncooked fires",
            "Refill the basket by\nplacing the bag here",
           
            "Grab the basket",
            "Place the basket\nin the fryer",
            "Wait for the fries\nto finish cooking",
            "Take the fires out of\nthe fryer before they burn",
            "Grab the scoop",
            "Scoop fries out\nof the basket",
            "Grab an empty\nfry container",
            "Put the scooped fries into\nthe container",
            "Put the container of fries\nin the paper bag",

            "Grab a cup",
            "Place the cup on the machine",
            "Press the start button",
            "Wait for the machine to finish",
            "Grab the mixed shake",
            "Put the shake in the bag",

            "Give the bag to customer\nby putting it out the window",

            "Congradulations on completing the tutorial!",
        };
        if (PlayerPrefs.HasKey("tutorial"))
        {
            if(PlayerPrefs.GetString("tutorial") == "complete")
            {
                gameObject.SetActive(false);
            }
        }
        if (PlayerPrefs.HasKey("step"))
        {
            currentStep = PlayerPrefs.GetInt("step");
        }
        else
        {
            currentStep = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (currentStep >= arrowPositions.Length)
        {
            transform.position = new Vector3(0, -10, 0);
        }
        else
        {
            transform.position = arrowPositions[currentStep].position;
            arrowText.text = taskText[currentStep];
        }
    }

    public void incrementStep(int step)
    {
        currentStep = step + 1;
        PlayerPrefs.SetInt("step", currentStep);
        PlayerPrefs.Save();
    }

    public void incrementIfBasket(SelectEnterEventArgs args)
    {
        if (args.interactorObject.transform.CompareTag("Player"))
        {
            if (currentStep == 21)
            {
                incrementStep(21);
            }
            else if (currentStep == 25)
            {
                incrementStep(25);
            }
        }
    }

    public void incrementIfScoop(SelectEnterEventArgs args)
    {
        if (args.interactorObject.transform.CompareTag("Player"))
        {
            if (currentStep == 21)
            {
                incrementStep(21);
            }
            else if (currentStep == 25)
            {
                incrementStep(25);
            }
        }
    }

    public void incrementIfFridge(SelectEnterEventArgs args)
    {
        if (args.interactorObject.transform.CompareTag("Player"))
        {
            if (currentStep == 0)
            {
                incrementStep(0);
            }
            else if (currentStep == 18)
            {
                incrementStep(18);
            }
        }
    }

    public void incrementIfFryBag(SelectEnterEventArgs args)
    {
        if (args.interactorObject.transform.CompareTag("Player"))
        {
            if (currentStep == 19)
            {
                incrementStep(19);
            }
        }
    }
    
    public void incrementIfBurgerBag(SelectEnterEventArgs args)
    {
        if (args.interactorObject.transform.CompareTag("Player"))
        {
            if (currentStep == 1)
            {
                incrementStep(1);
            }
        }
    }

    public void incrementIfBotBun(SelectEnterEventArgs args)
    {
        if (args.interactorObject.transform.CompareTag("Player"))
        {
            if (currentStep == 8)
            {
                incrementStep(8);
            }
        }
    }

    public void incrementIfTopBun(SelectEnterEventArgs args)
    {
        if (args.interactorObject.transform.CompareTag("Player"))
        {
            if (currentStep == 14)
            {
                incrementStep(14);
            }
        }
    }

    public void incrementIfCheese(SelectEnterEventArgs args)
    {
        if (args.interactorObject.transform.CompareTag("Player"))
        {
            if (currentStep == 12)
            {
                incrementStep(12);
            }
        }
    }

    public void incrementIfBurger()
    {
        if (currentStep == 9 || currentStep == 11 || currentStep == 13 || currentStep == 15)
        {
            incrementStep(currentStep);
        }
    }

    public void incrementIfShake(SelectEnterEventArgs args)
    {
        if (args.interactorObject.transform.CompareTag("Player"))
        {
            if (currentStep == 30)
            {
                incrementStep(30);
            }
            if (currentStep == 34)
            {
                incrementStep(34);
            }
        }
    }
}
