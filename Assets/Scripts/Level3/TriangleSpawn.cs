using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleSpawn : MonoBehaviour
{
    public float spawnRateTriangle;
    public GameObject TrianglePrefab;
    private float nextTimeToSpawn = 0f;

    //REFERENCIA PLAYER
    public PlayerMovementLvl1 playerRef;
    private void Start()
    {
        nextTimeToSpawn = Time.time + 1f / spawnRateTriangle;
    }

    void Update()
    {
        if (Time.time >= nextTimeToSpawn && playerRef.timer > 15f)
        {
            Instantiate(TrianglePrefab, Vector3.zero, Quaternion.identity);
            nextTimeToSpawn = Time.time + 1f / spawnRateTriangle;
        }
        if (playerRef.timer > 30f)
        {
            spawnRateTriangle = 0.07f;
        }
    }
}
