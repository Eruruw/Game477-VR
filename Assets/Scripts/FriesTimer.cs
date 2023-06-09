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
    private IngredientController IC;

    // Start is called before the first frame update
    void Start()
    {
        fries[1].SetActive(false);
        fries[2].SetActive(false);
        fries[0].SetActive(false);
        friesCount = 3;
        timer = 0;
        IC = GetComponent<IngredientController>();
    }

    private void Update()
    {
        if (cooking)
        {
            timer += Time.deltaTime;
            if (timer > cookTime)
            {
                gameObject.tag = "cookedFries";
                IC.foodVal = 10;

                if (tutorial.currentStep == 23)
                {
                    tutorial.incrementStep(23);
                }

                //insert code to change fries model to cooked here
            }
            if (timer > 450)
            {
                gameObject.tag = "overcookedFries";
                IC.foodVal = 0;
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
            fries[1].SetActive(true);
            fries[2].SetActive(true);
            fries[0].SetActive(true);
            friesCount = 0;
            Destroy(c.gameObject);
            if (tutorial.currentStep == 20)
            {
                tutorial.incrementStep(20);
            }
        }

        if (c.CompareTag("fryer"))
        {
            cooking = true;
            Game.globalInstance.sndPlayer.PlaySound(SoundType.FRIES_COOK, GetComponent<AudioSource>());

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
            Game.globalInstance.sndPlayer.PlaySound(SoundType.ITEM_COMPLETE, GetComponent<AudioSource>());

            if (tutorial.currentStep == 24)
            {
                tutorial.incrementStep(24);
            }
        }
    }
}
