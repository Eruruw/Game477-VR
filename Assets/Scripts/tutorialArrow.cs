using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class tutorialArrow : MonoBehaviour
{
    private Dictionary<int, Vector3> taskPos;
    private Dictionary<int, string> taskText;
    public Transform[] arrowPositions;
    public int currentStep;
    public TMP_Text arrowText;

    // Start is called before the first frame update
    void Start()
    {
        taskPos = new Dictionary<int, Vector3>()
        {
            {0, arrowPositions[0].position},
            {1, arrowPositions[1].position},
            {2, arrowPositions[2].position},
            {3, arrowPositions[3].position},
            {4, arrowPositions[4].position},
            {5, arrowPositions[5].position},
            {6, arrowPositions[6].position},
            {7, arrowPositions[7].position},
            {8, arrowPositions[8].position},
            {9, arrowPositions[9].position},
            {10, arrowPositions[10].position},
            {11, arrowPositions[11].position},
            {12, arrowPositions[12].position},
            {13, arrowPositions[13].position},
            {14, arrowPositions[14].position},
            {15, arrowPositions[15].position},
            {16, arrowPositions[16].position},
            {17, arrowPositions[17].position},
            {18, arrowPositions[18].position},
            {19, arrowPositions[19].position},
            {20, arrowPositions[20].position},
            {21, arrowPositions[21].position},
            {22, arrowPositions[22].position},
            {23, arrowPositions[23].position},
            {24, arrowPositions[24].position},
            {25, arrowPositions[25].position},
            {26, arrowPositions[26].position},
            {27, arrowPositions[27].position},
            {28, arrowPositions[28].position},
            {29, arrowPositions[29].position},
        };

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
        };

        currentStep = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = taskPos[currentStep];
        arrowText.text = taskText[currentStep];
    }

    public void incrementStep()
    {
        currentStep++;
    }
}
