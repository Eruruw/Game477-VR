using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private Vector3 origPos;
    private Quaternion origRot;
    // Start is called before the first frame update
    void Start()
    {
        origPos = transform.position;
        origRot = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void resetPos()
    {
        transform.position = origPos;
        transform.rotation = origRot;
    }
}
