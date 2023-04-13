using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CloneSocketObject : MonoBehaviour
{
    public GameObject clonePrefab;
    public int numObjs = 0;

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
    }

    public void CloneInteractable()
    {
        Instantiate(clonePrefab, gameObject.transform.position, gameObject.transform.rotation);
    }
}