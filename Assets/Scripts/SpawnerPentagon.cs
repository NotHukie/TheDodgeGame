using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerPentagon : MonoBehaviour
{
    public float spawnRatePentagon;
    public GameObject PentagonPrefab;
    public static float timer;
    public float secondsIncreasedPerFrame = 1;
    private float nextTimeToSpawn = 0f;
    
    void Start()
    {
        timer = 0;
    }
    
    void Update()
    {
        timer += secondsIncreasedPerFrame * Time.deltaTime;

        if(Time.time >= nextTimeToSpawn && timer > 16f)
        {
            Instantiate(PentagonPrefab, Vector3.zero, Quaternion.identity);
            nextTimeToSpawn = Time.time + 1f / spawnRatePentagon;
        }

        if (timer > 19.5f)
        {
            spawnRatePentagon = 0.125f;
        }
        
        if (timer > 23f)
        {
            spawnRatePentagon = 0.25f;
        }

        if (timer > 93f)
        {
            spawnRatePentagon = 0f;
        }
    }
}
