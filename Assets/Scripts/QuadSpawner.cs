using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadSpawner : MonoBehaviour
{
    public float spawnRateQuad;
    public GameObject QuadPrefab;


    private float nextTimeToSpawn = 0f;
    private void Start()
    {
        nextTimeToSpawn = Time.time + 1f / spawnRateQuad;
    }

    void Update()
    {
        if (Time.time >= nextTimeToSpawn)
        {
            Instantiate(QuadPrefab, Vector3.zero, Quaternion.identity);
            nextTimeToSpawn = Time.time + 1f / spawnRateQuad;
        }
    }
}
