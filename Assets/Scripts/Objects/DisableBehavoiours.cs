using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

[RequireComponent(typeof(NetworkIdentity))]
public class DisableBehavoiours : MonoBehaviour
{
    public Behaviour[] scriptsToDisable;
    public GameObject[] obj;
    void Start()
    {
        if (!GetComponent<NetworkIdentity>().isLocalPlayer)
        {
            foreach (Behaviour j in scriptsToDisable)
                j.enabled = false;
            foreach(GameObject ob in obj)
            {
                Destroy(ob);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
