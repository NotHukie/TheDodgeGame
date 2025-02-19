using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuadSpawnerL : MonoBehaviour
{
    public float spawnRateQuad;
    public GameObject QuadPrefab;
    private float nextTimeToSpawn = 0f;

    //REFERENCIA PLAYER
    public PlayerMovementLvl1 playerRef;

    int level;

    private void Start()
    {
        nextTimeToSpawn = Time.time + 1f / spawnRateQuad;

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

        if (Time.time >= nextTimeToSpawn && playerRef.timer > 75.5f && level == 2)
        {
            Instantiate(QuadPrefab, Vector3.zero, Quaternion.identity);
            nextTimeToSpawn = Time.time + 1f / spawnRateQuad;
        }


        if (playerRef.timer > 85f && level == 2)
        {
            spawnRateQuad = 0.00f;
        }

        // SPAWNS LEVEL 3

        if (Time.time >= nextTimeToSpawn && playerRef.timer > 15f && level == 3)
        {
            Instantiate(QuadPrefab, Vector3.zero, Quaternion.identity);
            nextTimeToSpawn = Time.time + 1f / spawnRateQuad;
        }


        if (playerRef.timer > 53f && level == 3)
        {
            spawnRateQuad = 0f;
        }
    }
}
