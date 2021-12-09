using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBodyes : MonoBehaviour
{
    public GameObject prefab;
    public Vector3 addingForce = Vector3.zero;
    private float spawnPeriod = 8;
    private int spawnLimit = 50;

    private void Start()
    {
        StartCoroutine(Work());
    }

    private IEnumerator Work()
    {
        int progress = 0;
        while(progress <= spawnLimit)
        {
            Spawn();
            progress++;
            yield return new WaitForSeconds(spawnPeriod);
        }

    }
    private void Spawn()
    {
        Rigidbody rb = Instantiate(prefab, transform.position, transform.rotation).GetComponent<Rigidbody>();
        if (rb == null)
            return;

        rb.velocity += transform.TransformDirection(addingForce);
    }
}
