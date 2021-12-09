using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionParticleCreator : MonoBehaviour
{
    [SerializeField] private float minVelocityToSpawnParticle = 4f;
    [SerializeField] private float timeout = 0.5f;
    [SerializeField] private GameObject particlePrefab;

    private float nextTime = 0f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude < minVelocityToSpawnParticle)
            return;

        if (Time.time < nextTime)
            return;

        Vector3 point = collision.contacts[0].point;
        Quaternion rotation = Quaternion.LookRotation(collision.contacts[0].normal);

        Instantiate(particlePrefab, point, rotation, collision.transform);

        nextTime = Time.time + timeout;
    }
}
