using System;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BurgerSockets : MonoBehaviour
{
    public XRSocketInteractor socket;
    public Transform tf;
    public Transform socketTf;
    public InteractionLayerMask Layer;
    public InteractionLayerMask ingredientLayer;
    public InteractionLayerMask bottomLayer;
    public InteractionLayerMask BurgerLayer;
    private GameObject item = null;

    void Start()
    {
        socket = GetComponent<XRSocketInteractor>();
    }

    public void SocketCheck()
    {
        IXRSelectInteractable selItem = socket.GetOldestInteractableSelected();
        item = selItem.transform.gameObject;
        XRGrabInteractable grab = item.GetComponent<XRGrabInteractable>();
        grab.interactionLayers = Layer;
        if (item.CompareTag("bottomBun"))
        {
            tf.position = socketTf.position;
            item.tag = "burgerBottom";
            socket.interactionLayers = ingredientLayer;
        }
        if (item.CompareTag("topBun"))
        {
            GameObject bun = GameObject.FindWithTag("burgerBottom");
            XRGrabInteractable bunGrab = bun.GetComponent<XRGrabInteractable>();
            bunGrab.interactionLayers = BurgerLayer;
            socket.interactionLayers = bottomLayer;
        }
        SetPos();
        tf.Translate(0f, 0.02f, 0f);
    }

    private async void SetPos()
    {
        await Task.Delay(5);
        item.transform.position = tf.position;
        AddJoint();
    }

    private async void AddJoint()
    {
        if (item != null)
        {
            await Task.Delay(100);
            if (!item.CompareTag("burgerBottom"))
            {
                GameObject parent = GameObject.FindWithTag("burgerBottom");
                item.AddComponent<FixedJoint>();
                FixedJoint joint = item.GetComponent<FixedJoint>();
                Rigidbody rb = parent.GetComponent<Rigidbody>();
                joint.connectedBody = rb;
            }
        }
    }
}