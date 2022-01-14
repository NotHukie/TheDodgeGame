using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleSpawner : MonoBehaviour
{
    public float spawnRateTriangle;
    public GameObject TrianglePrefab;

    private float nextTimeToSpawn = 40f;

    void Update()
    {
        if(Time.time >= nextTimeToSpawn)
        {
            Instantiate(TrianglePrefab, Vector3.zero, Quaternion.identity);
            nextTimeToSpawn = Time.time + 1f / spawnRateTriangle;
        }
    }
}
