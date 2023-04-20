using SerializableCallback;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CloneSocketObject : MonoBehaviour
{
    public GameObject clonePrefab;
    public int numObjs = 0;
    private Collider col;
    private Rigidbody rb;
    private GameObject gameObjectClone;
    private bool capped;

    void FixedUpdate()
    {
        if (numObjs == 4 && capped)
        {
            capped = false;
            col.enabled = true;
            rb.isKinematic = false;
        }
    }

    public void CloneInteractable(SelectExitEventArgs args)
    {
        if (numObjs <= 3)
        {
            StartCoroutine(WaitThenSpawn(args));
        }
        if (numObjs == 4)
        {
            StartCoroutine(WaitThenSpawn(args));
            col = gameObjectClone.GetComponent<Collider>();
            rb = gameObjectClone.GetComponent<Rigidbody>();
            rb.isKinematic = true;
            col.enabled = false;
            capped = true;
        }
    }

    public void CloneInteractable()
    {
        Instantiate(clonePrefab, gameObject.transform.position, gameObject.transform.rotation);
    }

    public IEnumerator WaitThenSpawn(SelectExitEventArgs args)
    {
        yield return new WaitForSeconds(0.5f);
        IXRInteractor socket = args.interactorObject;
        GameObject gameObjectClone = Instantiate(clonePrefab, socket.transform.position, socket.transform.rotation);
        GameObject item = socket.transform.gameObject;
        item.GetComponent<XRSocketInteractor>().StartManualInteraction(gameObjectClone.GetComponent<IXRSelectInteractable>());
        clonePrefab = gameObjectClone;
        numObjs++;
    }
}