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

        if(Time.time >= nextTimeToSpawn && timer > 20)
        {
            Instantiate(PentagonPrefab, Vector3.zero, Quaternion.identity);
            nextTimeToSpawn = Time.time + 1f / spawnRatePentagon;
        }
    }
}
