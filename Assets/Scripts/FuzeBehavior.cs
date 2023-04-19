using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FuzeBehavior : MonoBehaviour
{
    public MachineController machineCon;
    public XRSocketInteractor socket;
    public InteractionLayerMask Layer;

    public void Replace()
    {
        machineCon.bustFuze = false;
    }

    public void RemoveLayer()
    {
        IXRSelectInteractable selItem = socket.GetOldestInteractableSelected();
        GameObject item = selItem.transform.gameObject;
        XRGrabInteractable grab = item.GetComponent<XRGrabInteractable>();
        grab.interactionLayers = Layer;
    }
}
