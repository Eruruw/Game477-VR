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
    private GameObject item;
    private IXRSelectInteractable selItem;
    private XRGrabInteractable grab;

    void Start()
    {
        IXRSelectInteractable selItem = socketObj.GetOldestInteractableSelected();
        GameObject item = selItem.transform.gameObject;
        XRGrabInteractable grab = item.GetComponent<XRGrabInteractable>();
    }

    void FixedUpdate()
    {
        if (numObjs == 3)
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
            GameObject item = selItem.transform.gameObject;
            XRGrabInteractable grab = item.GetComponent<XRGrabInteractable>();
            grab.enabled = false;
        }
    }

    public void CloneInteractable()
    {
        Instantiate(clonePrefab, gameObject.transform.position, gameObject.transform.rotation);
    }
}