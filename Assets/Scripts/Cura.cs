using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cura : MonoBehaviour
{
    public GameObject[] healPrefab;
    public float spawnRateHeal;
    private float nextTimeToSpawn = 0f;
    void Start()
    {
        nextTimeToSpawn = Time.time + 1f / spawnRateHeal;
    }
    void Update()
    {
        if(Time.time >= nextTimeToSpawn)
        {
            if (Score.instance.isRunning)
            {
                Instantiate(healPrefab[0], new Vector3(Random.Range(-8, 8), Random.Range(-4, 4), 0), transform.rotation);
                nextTimeToSpawn = Time.time + 1f / spawnRateHeal;
            }
        }
    }
}
