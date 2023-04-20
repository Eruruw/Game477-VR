using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Tutorials.Core.Editor;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class tutorialArrow : MonoBehaviour
{
    //private Dictionary<int, Vector3> taskPos;
    private Dictionary<int, string> taskText;
    public Transform[] arrowPositions;

    [SerializeField]
    public int currentStep;
    public TMP_Text arrowText;

    // Start is called before the first frame update
    void Start()
    {
        //taskPos = new Dictionary<int, Vector3>()
        //{
        //    {0, arrowPositions[0].position},
        //    {1, arrowPositions[1].position},
        //    {2, arrowPositions[2].position},
        //    {3, arrowPositions[3].position},
        //    {4, arrowPositions[4].position},
        //    {5, arrowPositions[5].position},
        //    {6, arrowPositions[6].position},
        //    {7, arrowPositions[7].position},
        //    {8, arrowPositions[8].position},
        //    {9, arrowPositions[9].position},
        //    {10, arrowPositions[10].position},
        //    {11, arrowPositions[11].position},
        //    {12, arrowPositions[12].position},
        //    {13, arrowPositions[13].position},
        //    {14, arrowPositions[14].position},
        //    {15, arrowPositions[15].position},
        //    {16, arrowPositions[16].position},
        //    {17, arrowPositions[17].position},
        //    {18, arrowPositions[18].position},
        //    {19, arrowPositions[19].position},
        //    {20, arrowPositions[20].position},
        //    {21, arrowPositions[21].position},
        //    {22, arrowPositions[22].position},
        //    {23, arrowPositions[23].position},
        //    {24, arrowPositions[24].position},
        //    {25, arrowPositions[25].position},
        //    {26, arrowPositions[26].position},
        //    {27, arrowPositions[27].position},
        //    {28, arrowPositions[28].position},
        //    {29, arrowPositions[29].position},
        //};

        taskText = new Dictionary<int, string>()
        {
            {0, "1. Open the fridge"},
            {1, "2. Grab the bag of\nburger patties"},
            {2, "3. Refill the stack of patties by\nplacing the bag here"},
                 
            {3, "4. Grab a patty"},
            {4, "5. Place the patty on\nthe griddle"},
            {5, "6. Wait for the burger to\nfinish cooking"},
            {6, "7. Take the buger off of\nthe griddle before it burns"},
            {7, "8. Bring the cooked patty\nover to the prep table"},
                 
                 
            {8, "9. Grab the bottom bun"},
            {9, "10. Place the bottom bun\non the tray"},
            {10, "11. Grab the cooked patty"},
            {11, "12. Place the cooked patty\non the bottom bun"},
            {12, "13. Grab the cheese"},
            {13, "14. Place the cheese\non the patty"},
            {14, "15. Grab the top bun"},
            {15, "16. Place the bun on\ntop of the cheese"},
            {16, "17. Grab the completed\nburger"},
            {17, "18. Place the burger\nin the paper bag"},
                  
                  
            {18, "19. Open the fridge"},
            {19, "20. Grab the bag of\nuncooked fires"},
            {20, "21. Refill the basket by\nplacing the bag here"},
                  
            {21, "22. Grab the basket"},
            {22, "23. Place the basket\nin the fryer"},
            {23, "24. Wait for the fries\nto finish cooking"},
            {24, "25. Take the fires out of\nthe fryer before they burn"},
            {25, "26. Grab the scoop"},
            {26, "27. Scoop fries out\nof the basket"},
            {27, "28. Grab an empty\nfry container"},
            {28, "29. Put the scooped fries into\nthe container"},
            {29, "30. Put the container of fries\nin the paper bag"},
        };

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

    public void incrementIfBurger(SelectEnterEventArgs args)
    {
        if (args.interactableObject.transform.CompareTag("bottomBun") || args.interactableObject.transform.CompareTag("cookedPatty") || args.interactableObject.transform.CompareTag("cheese") || args.interactableObject.transform.CompareTag("topBun"))
        {
            if (currentStep == 9 || currentStep == 11 || currentStep == 13 || currentStep == 15)
            {
                incrementStep(currentStep);
            }
        }
    }
}
