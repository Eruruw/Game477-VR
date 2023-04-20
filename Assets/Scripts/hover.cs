using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hover : MonoBehaviour
{
    public Transform parentPos;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, parentPos.position.y + 0.5f + Mathf.Sin(Time.time) * 0.125f, transform.position.z);
    }
}
