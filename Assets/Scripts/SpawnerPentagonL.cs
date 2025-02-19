using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnerPentagonL : MonoBehaviour
{
    public float spawnRatePentagon;
    public GameObject PentagonPrefab;
    private float nextTimeToSpawn = 0f;

    int level;

    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (sceneName == "LVL 2")
        {
            level = 2;
        }
        if (sceneName == "LVL 3")
        {
            level = 3;
        }
    }

    //REFERENCIA PLAYER
    public PlayerMovementLvl1 playerRef;
    void Update()
    {
        // SPAWNS LEVEL 2

        if (Time.time >= nextTimeToSpawn && playerRef.timer > 15f && level == 2)
        {
            Instantiate(PentagonPrefab, Vector3.zero, Quaternion.identity);
            nextTimeToSpawn = Time.time + 1f / spawnRatePentagon;
        }


        if (playerRef.timer > 22.5f && level == 2)
        {
            spawnRatePentagon = 0.1f;
        }
        if (playerRef.timer > 30f && level == 2)
        {
            spawnRatePentagon = 0.13f;
        }
        if (playerRef.timer > 59f && level == 2)
        {
            spawnRatePentagon = 0.25f;
        }
        if (playerRef.timer > 66f && level == 2)
        {
            spawnRatePentagon = 0.10f;
        }
        if (playerRef.timer > 74f && level == 2)
        {
            spawnRatePentagon = 0.25f;
        }
        if (playerRef.timer > 84f && level == 2)
        {
            spawnRatePentagon = 0.10f;
        }
        if (playerRef.timer > 82f && level == 2)
        {
            spawnRatePentagon = 0f;
        }

        // SPAWNS LEVEL 3

        if(Time.time >= nextTimeToSpawn && playerRef.timer > 7.5f && level == 3)
        {
            Instantiate(PentagonPrefab, Vector3.zero, Quaternion.identity);
            nextTimeToSpawn = Time.time + 1f / spawnRatePentagon;
            spawnRatePentagon = 0.28125f;
        }
        if(playerRef.timer > 10f && level == 3)
        {
            spawnRatePentagon = 0f;
        }
    }
}
