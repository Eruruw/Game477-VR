using SerializableCallback;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FriesTimer : MonoBehaviour
{
    public GameObject[] fries;
    public int friesCount;
    public GameObject scoopFries;
    public float timer;
    public float cookTime = 30f;
    public bool cooking;
    public tutorialArrow tutorial;

    // Start is called before the first frame update
    void Start()
    {
        fries[1].SetActive(true);
        fries[2].SetActive(true);
        fries[0].SetActive(true);
        friesCount = 0;
        timer = 0;
    }

    private void Update()
    {
        if (cooking)
        {
            timer += Time.deltaTime;
            if (timer > cookTime)
            {
                gameObject.tag = "cookedFries";

                if (tutorial.currentStep == 23)
                {
                    tutorial.incrementStep(23);
                }

                //insert code to change fries model to cooked here
            }
            if (timer > 45)
            {
                gameObject.tag = "overcookedFries";
                //insert code to change fries model to overcooked here
            }
        }
    }

    private void OnTriggerEnter(Collider c)
    {
        if (c.CompareTag("emptyScoop") && gameObject.CompareTag("cookedFries") && !cooking)
        {


            scoopFries.SetActive(true);
            c.gameObject.tag = "fullScoop";
            fries[friesCount].SetActive(false);
            friesCount++;

            if (tutorial.currentStep == 26)
            {
                tutorial.incrementStep(26);
            }

            if (friesCount >= fries.Length)
            {
                gameObject.tag = "emptyBasket";
            }
        }

        if (c.CompareTag("fryBag") && gameObject.CompareTag("emptyBasket") && !cooking)
        {
            Start();
            Destroy(c.gameObject);
        }

        if (c.CompareTag("fryer"))
        {
            cooking = true;

            if (tutorial.currentStep == 22)
            {
                tutorial.incrementStep(22);
            }
        }

        if (c.CompareTag("trash"))
        {
            fries[1].SetActive(false);
            fries[2].SetActive(false);
            fries[0].SetActive(false);
            friesCount = 3;
            gameObject.tag = "emptyBasket";
        }
    }

    private void OnTriggerExit(Collider c)
    {
        if (c.CompareTag("fryer"))
        {
            cooking = false;

            if (tutorial.currentStep == 24)
            {
                tutorial.incrementStep(24);
            }
        }
    }
}
