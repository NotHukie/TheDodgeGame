using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectangleSpawn : MonoBehaviour
{
    public float spawnRateRectangle;
    public GameObject RectanglePrefab;
    private float nextTimeToSpawn = 0f;

    //REFERENCIA PLAYER

    public PlayerMovementLvl1 playerRef;

    void Update()
    {

        if (Time.time >= nextTimeToSpawn)
        {
            Instantiate(RectanglePrefab, new Vector3(Random.Range(-9, 9), Random.Range(6, 7), 0), transform.rotation);
            nextTimeToSpawn = Time.time + 1f / spawnRateRectangle;
        }

        if (playerRef.timer > 30f)
        {
            spawnRateRectangle = 1f;
        }
        if (playerRef.timer > 60f)
        {
            spawnRateRectangle = 4f;
        }
        if (playerRef.timer > 67f)
        {
            spawnRateRectangle = 2f;
        }
        if (playerRef.timer > 75f)
        {
            spawnRateRectangle = 4f;
        }
        if (playerRef.timer > 85f)
        {
            spawnRateRectangle = 1f;
        }
        if (playerRef.timer > 87f)
        {
            spawnRateRectangle = 0f;
        }
    }
}
