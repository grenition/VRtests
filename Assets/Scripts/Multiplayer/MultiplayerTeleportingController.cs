using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class MultiplayerTeleportingController : MonoBehaviour
{
    public static MultiplayerTeleportingController instance;
    public GameObject TeleportingPrefab;

    private void Awake()
    {
        instance = this;

        TeleportArea[] ars = GameObject.FindObjectsOfType<TeleportArea>();
        foreach (var ar in ars)
            ar.enabled = false;
    }
    public void InstantiateTeleporting()
    {
        Instantiate(TeleportingPrefab);
        TeleportArea[] ars = GameObject.FindObjectsOfType<TeleportArea>();
        foreach (var ar in ars)
            ar.enabled = true;
    }
}
