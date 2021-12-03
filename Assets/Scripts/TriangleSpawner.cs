using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleSpawner : MonoBehaviour
{
    public float spawnRateTriangle;
    public GameObject TrianglePrefab;


    private float nextTimeToSpawn = 0f;
    private void Start()
    {
        nextTimeToSpawn = Time.time + 1f / spawnRateTriangle;
    }

    void Update()
    {
        if(Time.time >= nextTimeToSpawn)
        {
            Instantiate(TrianglePrefab, Vector3.zero, Quaternion.identity);
            nextTimeToSpawn = Time.time + 1f / spawnRateTriangle;
        }
    }
}

