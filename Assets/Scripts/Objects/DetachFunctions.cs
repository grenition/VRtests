using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class DetachFunctions : MonoBehaviour
{
    private Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void DetachFromOtherObject()
    {
        rb.isKinematic = false;
        transform.parent = null;
    }
}
