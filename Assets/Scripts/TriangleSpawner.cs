using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleSpawner : MonoBehaviour
{
    public float spawnRateTriangle;
    public GameObject TrianglePrefab;

    private float nextTimeToSpawn = 0f;


    void Update()
    {
        if(Time.time >= nextTimeToSpawn && SpawnerPentagon.timer > 24f)
        {
            Instantiate(TrianglePrefab, Vector3.zero, Quaternion.identity);
            nextTimeToSpawn = Time.time + 1f / spawnRateTriangle;
        }

        if (SpawnerPentagon.timer > 55f)
        {
            spawnRateTriangle = 0f;
        }
    }
}
