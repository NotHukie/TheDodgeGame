using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerExterior : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] circlePrefabs;
    public float spawnRateCircle;
    private float nextTimeToSpawn = 0f;
    void Update()
    {
        if(Time.time >= nextTimeToSpawn)
        {
            Instantiate(circlePrefabs[0], spawnPoints[Random.Range(0, spawnPoints.Length)].position, transform.rotation);
            nextTimeToSpawn = Time.time + 1f / spawnRateCircle;
        }
    }
}

