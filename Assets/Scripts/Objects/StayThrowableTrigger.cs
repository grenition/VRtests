using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class StayThrowableTrigger : MonoBehaviour
{
    public string tagObject = "mag";
    public Transform attachPoint;

    private GameObject currentObject;
    private void OnTriggerEnter(Collider other)
    {
        if (currentObject != null)
            return;
        if (other.gameObject.tag != tagObject)
            return;
        if (!other.gameObject.TryGetComponent(out Interactable inter))
            return;

        if (!inter.attachedToHand)
            return;
        currentObject = inter.gameObject;
        inter.attachedToHand.DetachObject(inter.gameObject);
        inter.attachedToHand = null;
        inter.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        inter.gameObject.GetComponent<Collider>().enabled = false;
        other.gameObject.transform.parent = gameObject.transform;
        other.transform.position = attachPoint.position;
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == currentObject)
        if(currentObject != null)
            currentObject.gameObject.GetComponent<Collider>().enabled = true;
    }
}
