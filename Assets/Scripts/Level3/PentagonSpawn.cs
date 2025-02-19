using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PentagonSpawn : MonoBehaviour
{
    public float spawnRatePentagon;
    public GameObject PentagonPrefab;
    private float nextTimeToSpawn = 0f;

    //REFERENCIA PLAYER
    public PlayerMovementLvl1 playerRef;
    void Update()
    {

        if (Time.time >= nextTimeToSpawn)
        {
            Instantiate(PentagonPrefab, Vector3.zero, Quaternion.identity);
            nextTimeToSpawn = Time.time + 1f / spawnRatePentagon;
        }

        if (playerRef.timer > 30f)
        {
            spawnRatePentagon = 0.1f;
        }
    }
}
