using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriesTimer : MonoBehaviour
{
    public GameObject[] fries;
    public int friesCount;
    public bool canFries;
    public GameObject scoopFries;

    // Start is called before the first frame update
    void Start()
    {
        fries[0].SetActive(true);
        fries[1].SetActive(true);
        fries[2].SetActive(true);
        friesCount = 0;
        canFries = true;
    }

    private void OnTriggerEnter(Collider c)
    {
        if (c.CompareTag("emptyScoop") && canFries)
        {
            scoopFries.SetActive(true);
            c.gameObject.tag = "fullScoop";
            fries[friesCount].SetActive(false);
            friesCount++;
            if (friesCount >= fries.Length)
            {
                canFries = false;
            }
        }
        if (c.CompareTag("fryBag"))
        {
            Start();
        }
    }
}
