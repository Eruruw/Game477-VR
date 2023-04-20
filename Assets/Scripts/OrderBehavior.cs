using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderBehavior : MonoBehaviour
{
    public OrderController orderCon;

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.CompareTag("check"))
        {
            orderCon.CheckOrder();
        }
    }
}
