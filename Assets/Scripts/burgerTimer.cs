using System.Collections;
using System.Collections.Generic;
using Unity.Tutorials.Core.Editor;
using UnityEngine;

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

                if (tutorial.currentStep == 4)
                {
                    tutorial.incrementStep(4);
                }

                //insert code to change patty model to cooked here
            }
            if (timer > 45)
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
            cooking = true;
            if (tutorial.currentStep == 4)
            {
                tutorial.incrementStep(4);
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("griddle"))
        {
            cooking = false;
        }
    }
}
