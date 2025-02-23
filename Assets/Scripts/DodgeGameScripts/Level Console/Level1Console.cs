using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1Console : MonoBehaviour
{
    [Header("CIRCLE")]
    public Transform[] spawnPointsCircle;
    public GameObject circlePrefab;
    private float nextTimeToSpawnCircle = 0f;
    [SerializeField] private bool isCircleSpawning;
    [SerializeField] private float spawnRateCircle;

    [Header("BLOCK")]
    public GameObject BlockPrefab;
    private float nextTimeToSpawnBlock = 0f;
    [SerializeField] private bool isBlockSpawning;
    [SerializeField] private float spawnRateBlock;

    [Header("HEX")]
    public GameObject hexPrefab;
    private float nextTimeToSpawnHex = 0f;
    [SerializeField] private bool isHexSpawning;
    [SerializeField] private float spawnRateHex;

    [Header("TRI")]
    public GameObject TriPrefab;
    private float nextTimeToSpawnTri = 0f;
    [SerializeField] private bool isTriSpawning;
    [SerializeField] private float spawnRateTri;

    [Header("QUAD")]
    public GameObject QuadPrefab;
    private float nextTimeToSpawnQuad = 0f;
    [SerializeField] private bool isQuadSpawning;
    [SerializeField] private float spawnRateQuad;

    [Header("L")]
    public GameObject[] LPrefab;
    private float nextTimeToSpawnL = 0f;
    [SerializeField] private bool isLSpawning;
    [SerializeField] private float spawnRateL;

    string currentSceneName;

    private void Start()
    {
        currentSceneName = SceneManager.GetActiveScene().name; // GET CURRENT SCENE NAME // 

        StartCoroutine(LevelManager());
    }
    private void Update()
    {
        if (Time.time >= nextTimeToSpawnCircle && isCircleSpawning) // WHAT TIMES CIRCLE TO SPAWN //
        {
            SpawnCircle();
        }
        if (Time.time >= nextTimeToSpawnBlock && isBlockSpawning) // WHAT TIMES BLOCK TO SPAWN //
        {
            SpawnBlock();
        }
        if (Time.time >= nextTimeToSpawnHex && isHexSpawning) // WHAT TIMES HEX TO SPAWN //
        {
            SpawnHex();
        }
        if (Time.time >= nextTimeToSpawnTri && isTriSpawning) // WHAT TIMES TRI TO SPAWN //
        {
            SpawnTri();
        }
        if (Time.time >= nextTimeToSpawnQuad && isQuadSpawning) // WHAT TIMES QUAD TO SPAWN //
        {
            SpawnQuad();
        }
        if (Time.time >= nextTimeToSpawnL && isLSpawning) // WHAT TIMES L TO SPAWN //
        {
            Invoke("SpawnL", 0f);
            Invoke("SpawnL1", 0.5f);
            nextTimeToSpawnL = Time.time + 1f / spawnRateL;
        }

        if (Input.GetKeyDown(KeyCode.R)) // RELOAD CURRENT SCENE //
        {
            SceneManager.LoadScene(currentSceneName);
        }
        
    }
    void SpawnCircle() // WHAT MAKE CIRCLE SPAWN //
    {
        Instantiate(circlePrefab, spawnPointsCircle[Random.Range(0, spawnPointsCircle.Length)].position, transform.rotation);
        nextTimeToSpawnCircle = Time.time + 1f / spawnRateCircle;
    }
    void SpawnBlock() // WHAT MAKE BLOCK SPAWN //
    {
        Instantiate(BlockPrefab, new Vector3(Random.Range(-9, 9), Random.Range(6, 7), 0), transform.rotation);
        nextTimeToSpawnBlock = Time.time + 1f / spawnRateBlock;
    }
    void SpawnHex() // WHAT MAKE HEX SPAWN //
    {
        Instantiate(hexPrefab, Vector3.zero, Quaternion.identity);
        nextTimeToSpawnHex = Time.time + 1f / spawnRateHex;
    }
    void SpawnTri() // WHAT MAKE TRI SPAWN //
    {
        Instantiate(TriPrefab, Vector3.zero, Quaternion.identity);
        nextTimeToSpawnTri = Time.time + 1f / spawnRateTri;
    }
    void SpawnQuad() // WHAT MAKE QUAD SPAWN //
    {
        Instantiate(QuadPrefab, Vector3.zero, Quaternion.identity);
        nextTimeToSpawnQuad = Time.time + 1f / spawnRateQuad;
    }
    void SpawnL() // WHAT MAKE L SPAWN //
    {
        Instantiate(LPrefab[Random.Range(0, LPrefab.Length)], new Vector3(-6f, 8f, 0f), transform.rotation);
        Instantiate(LPrefab[Random.Range(0, LPrefab.Length)], new Vector3(2f, 8f, 0f), transform.rotation);
    }
    void SpawnL1() // WHAT MAKE L SPAWN //
    {
        Instantiate(LPrefab[Random.Range(0, LPrefab.Length)], new Vector3(-2f, 8f, 0f), transform.rotation);
        Instantiate(LPrefab[Random.Range(0, LPrefab.Length)], new Vector3(6f, 8f, 0f), transform.rotation);
    }

    private IEnumerator LevelManager() // LEVEL TIMING MANAGER //
    {
        yield return new WaitForSeconds(10f);
    }


}
