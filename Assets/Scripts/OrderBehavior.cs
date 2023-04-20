using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderBehavior : MonoBehaviour
{
    public OrderController orderCon;
    private Vector3 origPos;
    private Quaternion origRot;

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
        }
    }
}
