using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriangleSpawnerL : MonoBehaviour
{
    public float spawnRateTriangle;
    public GameObject TrianglePrefab;
    private float nextTimeToSpawn = 0f;

    //REFERENCIA PLAYER
    public PlayerMovementLvl1 playerRef;

    int level;

    private void Start()
    {
        nextTimeToSpawn = Time.time + 1f / spawnRateTriangle;

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

    void Update()
    {
        // SPAWNS LEVEL 2

        if (Time.time >= nextTimeToSpawn && playerRef.timer > 30f && level == 2)
        {
            Instantiate(TrianglePrefab, Vector3.zero, Quaternion.identity);
            nextTimeToSpawn = Time.time + 1f / spawnRateTriangle;
        }


        if (playerRef.timer > 60f && level == 2) 
        {
            spawnRateTriangle = 0.15f;
        }
        if (playerRef.timer > 67f && level == 2)
        {
            spawnRateTriangle = 0.08f;
        }
        if (playerRef.timer > 75f && level == 2)
        {
            spawnRateTriangle = 0.15f;
        }
        if (playerRef.timer > 80f && level == 2)
        {
            spawnRateTriangle = 0f;
        }

        // SPAWNS LEVEL 3

    }
}
