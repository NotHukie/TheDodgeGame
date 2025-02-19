using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawn : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] circlePrefabs;
    public float spawnRateCircle;
    private float nextTimeToSpawn = 0f;

    //REFERENCIA PLAYER
    public PlayerMovementLvl1 playerRef;

    void Update()
    {
        if (Time.time >= nextTimeToSpawn)
        {
            Instantiate(circlePrefabs[0], spawnPoints[Random.Range(0, spawnPoints.Length)].position, transform.rotation);
            nextTimeToSpawn = Time.time + 1f / spawnRateCircle;
        }

        if (playerRef.timer > 15f)
        {
            spawnRateCircle = 1.6f;
        }
        if (playerRef.timer > 63f)
        {
            spawnRateCircle = 1f;
        }
        if (playerRef.timer > 71f)
        {
            spawnRateCircle = 1.6f;
        }
        if (playerRef.timer > 81f)
        {
            spawnRateCircle = 1f;
        }
        if (playerRef.timer > 86f)
        {
            spawnRateCircle = 0f;
        }

    }
}
