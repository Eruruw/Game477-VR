using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Tutorials.Core.Editor;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class tutorialArrow : MonoBehaviour
{
    private Dictionary<int, string> taskText;
    public Transform[] arrowPositions;

    [SerializeField]
    public int currentStep;
    public TMP_Text arrowText;

    // Start is called before the first frame update
    void Start()
    {

        taskText = new Dictionary<int, string>()
        {
            {0, "Open the fridge"},
            {1, "Grab the bag of\nburger patties"},
            {2, "Refill the stack of patties by\nplacing the bag here"},
                 
            {3, "Grab a patty"},
            {4, "Place the patty on\nthe griddle"},
            {5, "Wait for the burger to\nfinish cooking"},
            {6, "Take the buger off of\nthe griddle before it burns"},
            {7, "Bring the cooked patty\nover to the prep table"},
                 
                 
            {8, "Grab the bottom bun"},
            {9, "Place the bottom bun\non the tray"},
            {10, "Grab the cooked patty"},
            {11, "Place the cooked patty\non the bottom bun"},
            {12, "Grab the cheese"},
            {13, "Place the cheese\non the patty"},
            {14, "Grab the top bun"},
            {15, "Place the bun on\ntop of the cheese"},
            {16, "Grab the completed\nburger"},
            {17, "Place the burger\nin the paper bag"},
                  
                  
            {18, "Open the fridge"},
            {19, "Grab the bag of\nuncooked fires"},
            {20, "Refill the basket by\nplacing the bag here"},
                  
            {21, "Grab the basket"},
            {22, "Place the basket\nin the fryer"},
            {23, "Wait for the fries\nto finish cooking"},
            {24, "Take the fires out of\nthe fryer before they burn"},
            {25, "Grab the scoop"},
            {26, "Scoop fries out\nof the basket"},
            {27, "Grab an empty\nfry container"},
            {28, "Put the scooped fries into\nthe container"},
            {29, "Put the container of fries\nin the paper bag"},
            {30, "Give the bag to customer\nby putting it out the window"},
        };
        if (PlayerPrefs.HasKey("tutorial"))
        {
            if(PlayerPrefs.GetString("tutorial") == "complete")
            {
                gameObject.SetActive(false);
            }
        }
        currentStep = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = arrowPositions[currentStep].position;
        arrowText.text = taskText[currentStep];
    }

    public void incrementStep(int step)
    {
        currentStep = step + 1;
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
}
