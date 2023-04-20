using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashableObject : MonoBehaviour
{
    [SerializeField]
    private CloneSocketObject cloneSocket;

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.CompareTag("trash"))
        {
            Decrement();
            Destroy(gameObject);
        }
        else if(col.gameObject.CompareTag("socket"))
        {
            cloneSocket = col.gameObject.GetComponent<CloneSocketObject>();
        }
    }

    public void Decrement()
    {
        cloneSocket.numObjs--;
    }
}
