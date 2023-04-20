using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashableObject : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.CompareTag("trash"))
        {
            Destroy(gameObject);
        }
    }
}
