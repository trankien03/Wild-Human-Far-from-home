using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiretileLauncher : MonoBehaviour
{
    public GameObject projecttilePrefab;
    public Transform firePoint;

    public void FireProjectile()
    {
        Instantiate(projecttilePrefab, firePoint.position, projecttilePrefab.transform.rotation);
    }

}
