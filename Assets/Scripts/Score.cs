using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    
    public float scoreAmount;
    public float pointIncreasedPerSecond;
    public static Score instance = null;
    public bool isRunning;

    void Start()
    {
        scoreAmount = 0f;
        pointIncreasedPerSecond = 3f;
        isRunning = true;
    }
    private void Awake()
    {
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
    }
    void Update()
    {
        if (isRunning)
        {
            scoreAmount += pointIncreasedPerSecond * Time.deltaTime;
        }
    }
}
