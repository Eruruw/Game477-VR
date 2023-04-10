using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CloneSocketObject : MonoBehaviour
{
    public GameObject clonePrefab;

    public void CloneInteractable(SelectExitEventArgs args)
    {
        IXRInteractor socket = args.interactorObject;
        GameObject gameObjectClone = Instantiate(clonePrefab, socket.transform.position, socket.transform.rotation);
        GameObject item = socket.transform.gameObject;
        item.GetComponent<XRSocketInteractor>().StartManualInteraction(gameObjectClone.GetComponent<IXRSelectInteractable>());
    }
}