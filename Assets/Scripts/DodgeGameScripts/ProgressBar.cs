using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private float levelTime; // TEMPO TOTAL DE NIVEL

    private float timePlayed; // TEMPO JOGADO NO NIVEL
    private float progressPercentage; // VALOR EM FLOAT % DE LEVEL
    private float secondsIncreasedPerFrame = 1f;
    [HideInInspector] public int intProgressPercentage; // VALOR EM INT % DE LEVEL


    public Slider progressBar;
    void Start()
    {
        progressBar.maxValue = levelTime;
    }


    void Update()
    {
        timePlayed += secondsIncreasedPerFrame * Time.deltaTime;
        progressBar.value = timePlayed;

        progressPercentage = (timePlayed * 100) / levelTime;
        intProgressPercentage = (int)progressPercentage;
        if (intProgressPercentage >= 100)
        {
            intProgressPercentage = 100;
        }
    }
}
