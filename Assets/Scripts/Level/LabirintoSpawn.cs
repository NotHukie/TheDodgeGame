using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LabirintoSpawn : MonoBehaviour
{
    public GameObject[] labirintoPrefab;
    public float spawnRateLabirinto;
    private float nextTimeToSpawn = 0f;

    int level;

    //REFERENCIA PLAYER
    public PlayerMovementLvl1 playerRef;

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

    void Update()
    {

        if (level == 3 && Time.time >= nextTimeToSpawn && playerRef.timer > 59.5f)
        {
            Invoke("Spawn", 0f);
            Invoke("Spawn1", 0.5f);

            nextTimeToSpawn = Time.time + 1f / spawnRateLabirinto;
        }

        // SPAWNS LEVEL 3

        if (playerRef.timer > 86f && level == 3)
        {
            spawnRateLabirinto = 0f;
        }


    }

    void Spawn()
    {
        Instantiate(labirintoPrefab[Random.Range(0, labirintoPrefab.Length)], new Vector3(-6f, 8f, 0f), transform.rotation);
        Instantiate(labirintoPrefab[Random.Range(0, labirintoPrefab.Length)], new Vector3(2f, 8f, 0f), transform.rotation);
    }
    void Spawn1()
    {
        Instantiate(labirintoPrefab[Random.Range(0, labirintoPrefab.Length)], new Vector3(-2f, 8f, 0f), transform.rotation);
        Instantiate(labirintoPrefab[Random.Range(0, labirintoPrefab.Length)], new Vector3(6f, 8f, 0f), transform.rotation);
    }
}
