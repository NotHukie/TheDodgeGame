using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadSpawn : MonoBehaviour
{
    public float spawnRateQuad;
    public GameObject QuadPrefab;
    private float nextTimeToSpawn = 0f;

    //REFERENCIA PLAYER
    public PlayerMovementLvl1 playerRef;

    private void Start()
    {
        nextTimeToSpawn = Time.time + 1f / spawnRateQuad;
    }

    void Update()
    {
        if (Time.time >= nextTimeToSpawn && playerRef.timer > 45f)
        {
            Instantiate(QuadPrefab, Vector3.zero, Quaternion.identity);
            nextTimeToSpawn = Time.time + 1f / spawnRateQuad;
        }
    }
}
