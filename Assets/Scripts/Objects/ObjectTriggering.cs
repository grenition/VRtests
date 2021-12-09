using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using Valve.VR;
using UnityEngine.Events;

[RequireComponent(typeof(Interactable))]
public class ObjectTriggering : MonoBehaviour
{
    public UnityEvent onTriggerDown;
    [SerializeField] private SteamVR_Action_Boolean trigger;

    private Interactable interactable;

    private void Awake()
    {
        interactable = GetComponent<Interactable>();
    }

    private void Update()
    {
        if(interactable.attachedToHand != null)
        {
            SteamVR_Input_Sources source = interactable.attachedToHand.handType;
            if (trigger[source].stateDown)
            {
                onTriggerDown.Invoke();
            }
        }
    }
}
