using System;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class IngredientController : MonoBehaviour
{
    public int foodVal = 0;

    void Start()
    {
        if (gameObject.CompareTag("bottomBun"))
        {
            foodVal = 100000;
        }
        else if (gameObject.CompareTag("cheese"))
        {
            foodVal = 1000;
        }
        else if (gameObject.CompareTag("topBun"))
        {
            foodVal = 100;
        }
    }

    private async void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("check"))
        {
            OrderController check = col.GetComponent<OrderController>();
            check.checkOrder = check.checkOrder + foodVal;
            await Task.Delay(100);
            if (gameObject.CompareTag("cookedPatty") || gameObject.CompareTag("cheese") || gameObject.CompareTag("topBun"))
            {
                FixedJoint joint = gameObject.GetComponent<FixedJoint>();
                Destroy(joint);
            }
            Destroy(gameObject);
        }
        if(gameObject.CompareTag("milkshakeCup") && col.gameObject.CompareTag("milkTrigger"))
        {
            gameObject.tag = "milkshake";
            foodVal = 1;
        }
    }
}