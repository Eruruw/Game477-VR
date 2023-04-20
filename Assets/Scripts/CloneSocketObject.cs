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
    public XRSocketInteractor socketObj;
    private XRGrabInteractable grab;
    private bool capped;

    void FixedUpdate()
    {
        if (numObjs == 3 && capped)
        {
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
            IXRSelectInteractable selItem = socketObj.GetOldestInteractableSelected();
            GameObject itemObj = selItem.transform.gameObject;
            grab = itemObj.GetComponent<XRGrabInteractable>();
            grab.enabled = false;
            capped = true;
        }
    }

    public void CloneInteractable()
    {
        Instantiate(clonePrefab, gameObject.transform.position, gameObject.transform.rotation);
    }
}