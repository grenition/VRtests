using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using Valve.VR.InteractionSystem;

public class PlayerMultiplayerController : NetworkBehaviour
{
    [Header("Setup")]
    [SerializeField] private Object[] objectsToDestroy;
    [SerializeField] private GameObject[] objectsToDestroyIfLocalPlayer;
    [SerializeField] private Behaviour[] behavioursToDisableIfNotLocalPlayer;

    private void Start()
    {
        if (!isLocalPlayer)
        {
            foreach (Object obj in objectsToDestroy)
                Destroy(obj);
        }
        else
        {
            foreach (GameObject obj in objectsToDestroyIfLocalPlayer)
                obj.SetActive(false);
            foreach(Behaviour beh in behavioursToDisableIfNotLocalPlayer)
                beh.enabled = false;

            MultiplayerTeleportingController.instance.InstantiateTeleporting();
        }

    }
}
