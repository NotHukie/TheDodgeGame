using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LSurviveSpawn1 : MonoBehaviour
{
    public GameObject[] labirintoPrefab;
    public float spawnRateLabirinto;
    private float nextTimeToSpawn = 0f;



    void Update()
    {

        if (Time.time >= nextTimeToSpawn && SpawnerPentagon.timer > 146f)
        {
            Instantiate(labirintoPrefab[Random.Range(0, labirintoPrefab.Length)], new Vector3(-2f, 8f, 0f), transform.rotation);
            Instantiate(labirintoPrefab[Random.Range(0, labirintoPrefab.Length)], new Vector3(6f, 8f, 0f), transform.rotation);
            Invoke("Spawn", 0.5f);

            nextTimeToSpawn = Time.time + 1f / spawnRateLabirinto;
        }

    }
    void Spawn()
    {
        Instantiate(labirintoPrefab[Random.Range(0, labirintoPrefab.Length)], new Vector3(-6f, 8f, 0f), transform.rotation);
        Instantiate(labirintoPrefab[Random.Range(0, labirintoPrefab.Length)], new Vector3(2f, 8f, 0f), transform.rotation);
    }
}
