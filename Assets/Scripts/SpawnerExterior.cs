using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnerExterior : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] circlePrefabs;
    public float spawnRateCircle;
    private float nextTimeToSpawn = 0f;

    bool inLevels;
    int level;

    //REFERENCIA PLAYER
    public PlayerMovementLvl1 playerRef;

    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if(sceneName == "Survive")
        {
            inLevels = false;
        }
        if(sceneName == "LVL 2")
        {
            level = 2;
            inLevels = true;
        }
        if (sceneName == "LVL 3")
        {
            level = 3;
            inLevels = true;
        }
    }

    void Update()
    {
        if (Time.time >= nextTimeToSpawn)
        {
            Instantiate(circlePrefabs[0], spawnPoints[Random.Range(0, spawnPoints.Length)].position, transform.rotation);
            nextTimeToSpawn = Time.time + 1f / spawnRateCircle;
        }

        // SPAWNS LEVEL 2

        if (inLevels && playerRef.timer > 56f && level == 2)
        {
            spawnRateCircle = 1.6f;
        }
        if (inLevels && playerRef.timer > 63f && level == 2)
        {
            spawnRateCircle = 1f;
        }
        if (inLevels && playerRef.timer > 71f && level == 2)
        {
            spawnRateCircle = 1.6f;
        }
        if (inLevels && playerRef.timer > 81f && level == 2)
        {
            spawnRateCircle = 1f;
        }
        if (inLevels && playerRef.timer > 86f && level == 2)
        {
            spawnRateCircle = 0f;
        }

        // SPAWNS LEVEL 3

        if (inLevels && playerRef.timer > 74f && level == 3)
        {
            spawnRateCircle = 3f;
        }
        if (inLevels && playerRef.timer > 87f && level == 3)
        {
            spawnRateCircle = 0f;
        }
    }
}

