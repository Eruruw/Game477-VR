using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashableObject : MonoBehaviour
{
    public CloneSocketObject cloneSocket;

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.CompareTag("trash"))
        {
            cloneSocket.numObjs--;
            Destroy(gameObject);
        }
    }
}
