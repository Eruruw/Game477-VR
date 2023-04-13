using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriesTimer : MonoBehaviour
{
    public GameObject[] fries;
    public int friesCount;
    public GameObject scoopFries;
    public float timer;
    public float cookTime;
    public bool cooking;

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
                //insert code to change fries to cooked here
            }
            if (timer > 45)
            {
                gameObject.tag = "overcookedFries";
                //insert code to change fries to overcooked here
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
            if (friesCount >= fries.Length)
            {
                gameObject.tag = "emptyBasket";
            }
        }

        if (c.CompareTag("fryBag") && gameObject.CompareTag("emptyBasket") && !cooking)
        {
            Start();
        }

        if (c.CompareTag("fryer"))
        {
            cooking = true;
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
        }
    }
}
