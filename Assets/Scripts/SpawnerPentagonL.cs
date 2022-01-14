using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerPentagonL : MonoBehaviour
{
    public float spawnRatePentagon;
    public GameObject PentagonPrefab;


    private float nextTimeToSpawn = 0f;
    

    void Update()
    {
        if(Time.time >= nextTimeToSpawn)
        {
            Instantiate(PentagonPrefab, Vector3.zero, Quaternion.identity);
            nextTimeToSpawn = Time.time + 1f / spawnRatePentagon;
        }
    }
}
