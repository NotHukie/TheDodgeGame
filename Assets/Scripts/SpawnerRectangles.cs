using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnerRectangles : MonoBehaviour
{
    public float spawnRateRectangle;
    public GameObject RectanglePrefab;
    private float nextTimeToSpawn = 0f;

    bool inLevels;
    int level;

    //REFERENCIA PLAYER

    public PlayerMovementLvl1 playerRef;

    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (sceneName == "Survive")
        {
            inLevels = false;
        }
        if (sceneName == "LVL 2")
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
            Instantiate(RectanglePrefab, new Vector3(Random.Range(-9, 9), Random.Range(6, 7), 0), transform.rotation);
            nextTimeToSpawn = Time.time + 1f / spawnRateRectangle;
        }

        // SPAWNS LEVEL 2

        if (inLevels && playerRef.timer > 45f && level == 2)
        {
            spawnRateRectangle = 3f;
        }
        if (inLevels && playerRef.timer > 60f && level == 2)
        {
            spawnRateRectangle = 4f;
        }
        if (inLevels && playerRef.timer > 67f && level == 2)
        {
            spawnRateRectangle = 2f;
        }
        if (inLevels && playerRef.timer > 75f && level == 2)
        {
            spawnRateRectangle = 4f;
        }
        if (inLevels && playerRef.timer > 85f && level == 2)
        {
            spawnRateRectangle = 1f;
        }
        if (inLevels && playerRef.timer > 87f && level == 2)
        {
            spawnRateRectangle = 0f;
        }

        // SPAWNS LEVEL 3

        if (inLevels && playerRef.timer > 75f && level == 3)
        {
            spawnRateRectangle = 5f;
        }
        if (inLevels && playerRef.timer > 90f && level == 3)
        {
            spawnRateRectangle = 0f;
        }
    }

}
