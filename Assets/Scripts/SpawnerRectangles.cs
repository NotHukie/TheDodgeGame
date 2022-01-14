using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerRectangles : MonoBehaviour
{
    public float spawnRateRectangle;
    public GameObject RectanglePrefab;
    private float nextTimeToSpawn = 0f;
    
    void Start()
    {
        StartCoroutine(SpawnReta());
    }

    IEnumerator SpawnReta()
    {
        yield return new WaitForSeconds(10);
        Update();
    }
    void Update()
    {
        if(Time.time >= nextTimeToSpawn && Score.instance.isRunning)
        {
            Instantiate(RectanglePrefab, new Vector3(Random.Range(-9, 9), Random.Range(6, 7), 0), transform.rotation);
            nextTimeToSpawn = Time.time + 1f / spawnRateRectangle;
        }
    }

}
