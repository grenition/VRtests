using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    private bool destroyed = false;
    public float minVelocityToDestroy = 5f;
    public int hitsToDie = 5;
    public GameObject breakedProp;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > minVelocityToDestroy && !destroyed)
        {
            if (hitsToDie > 0)
                hitsToDie--;
            else
            {
                BreakMe();
                destroyed = true;
            }
        }
    }

    private void BreakMe()
    {
        Instantiate(breakedProp, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
