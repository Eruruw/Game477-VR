using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FuzeBehavior : MonoBehaviour
{
    public MachineController machineCon;
    public XRSocketInteractor socket;
    public InteractionLayerMask Layer;
    private XRGrabInteractable grab;

    public void Replace()
    {
        IXRSelectInteractable selItem = socket.GetOldestInteractableSelected();
        GameObject item = selItem.transform.gameObject;
        grab = item.GetComponent<XRGrabInteractable>();
        machineCon.bustFuze = false;
    }

    public void RemoveLayer()
    {
        grab.interactionLayers = Layer;
    }
}
