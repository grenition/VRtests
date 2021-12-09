using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleGun : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] private LayerMask shootingLayerMask;
    [Header("Trails")]
    [SerializeField] private Transform trailOutPoint;
    [SerializeField] private GameObject trailPrefab;
    [SerializeField] private float trailSpeed = 200f;
    public void Shoot()
    {
        bool shoot = Physics.Raycast(trailOutPoint.position, trailOutPoint.forward, out RaycastHit hit, 500f, shootingLayerMask);
        StartCoroutine(VisualizeTrail(shoot, hit.point));
        Debug.Log("Shooted");
    }
    private IEnumerator VisualizeTrail(bool hit, Vector3 target)
    {
        if (trailOutPoint == null)
            yield break;

        GameObject trail = Instantiate(trailPrefab, trailOutPoint.position, trailOutPoint.rotation);

        if (!hit)
        {
            target = trailOutPoint.forward * 500f;
        }

        while(Vector3.Distance(trail.transform.position, target) > 0.1f)
        {
            trail.transform.position = Vector3.Lerp(trail.transform.position, target, trailSpeed * Time.deltaTime);
            yield return null;
        }
        Destroy(trail);
    }
}
