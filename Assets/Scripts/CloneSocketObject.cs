using System;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CloneSocketObject : MonoBehaviour
{
    public GameObject clonePrefab;
    public int numObjs = 0;
    private XRGrabInteractable grab;
    private GameObject gameObjectClone;
    private bool capped;

    void FixedUpdate()
    {
        if (numObjs == 3 && capped)
        {
            capped = false;
            grab.enabled = true;
        }
    }

    public void CloneInteractable(SelectExitEventArgs args)
    {
        if (numObjs <= 3)
        {
            IXRInteractor socket = args.interactorObject;
            GameObject gameObjectClone = Instantiate(clonePrefab, socket.transform.position, socket.transform.rotation);
            GameObject item = socket.transform.gameObject;
            item.GetComponent<XRSocketInteractor>().StartManualInteraction(gameObjectClone.GetComponent<IXRSelectInteractable>());
            numObjs++;
        }
        if (numObjs == 4)
        {
            IXRInteractor socket = args.interactorObject;
            GameObject gameObjectClone = Instantiate(clonePrefab, socket.transform.position, socket.transform.rotation);
            GameObject item = socket.transform.gameObject;
            item.GetComponent<XRSocketInteractor>().StartManualInteraction(gameObjectClone.GetComponent<IXRSelectInteractable>());
            grab = gameObjectClone.GetComponent<XRGrabInteractable>();
            grab.enabled = false;
            capped = true;
            numObjs++;
        }
    }

    public void CloneInteractable()
    {
        Instantiate(clonePrefab, gameObject.transform.position, gameObject.transform.rotation);
    }
}