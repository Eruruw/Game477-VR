using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class friesContainer : MonoBehaviour
{
    public GameObject scoopFries;
    public GameObject containerFries;
    public bool canFill;


    // Start is called before the first frame update
    void Start()
    {
        canFill = true;
    }

    private void OnTriggerEnter(Collider c)
    {
        if (c.CompareTag("fullScoop") && canFill)
        {
            scoopFries.SetActive(false);
            containerFries.SetActive(true);
            canFill = false;
            c.gameObject.tag = "emptyScoop";
        }
    }
}
