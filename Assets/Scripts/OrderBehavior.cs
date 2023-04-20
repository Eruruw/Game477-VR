using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderBehavior : MonoBehaviour
{
    public OrderController orderCon;
    private Vector3 origPos;
    private Quaternion origRot;
    public tutorialArrow tutorial;

    void Start()
    {
        origPos = transform.position;
        origRot = transform.rotation;
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.CompareTag("check"))
        {
            orderCon.CheckOrder();
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            transform.rotation = origRot;
            transform.position = origPos;

            //insert message to state that tutorial is over
            if (tutorial.currentStep == 36)
            {
                tutorial.incrementStep(36);
            }
        }

        if (col.gameObject.CompareTag("burger"))
        {
            if (tutorial.currentStep == 17)
            {
                tutorial.incrementStep(17);
            }
        }

        if (col.gameObject.CompareTag("fries"))
        {
            if (tutorial.currentStep == 29)
            {
                tutorial.incrementStep(29);
            }
        }
        if (col.gameObject.CompareTag("milkshake"))
        {
            if (tutorial.currentStep == 35)
            {
                tutorial.incrementStep(35);
            }
        }
    }
}
