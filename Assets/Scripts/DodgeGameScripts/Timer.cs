using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    //Cron�metro para spawnar obst�culos
    private float timer;
    private float secondsIncreasedPerFrame = 1f;

    [SerializeField] TextMeshProUGUI timerText;

    void Start()
    {
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += secondsIncreasedPerFrame * Time.deltaTime; // Aumentar um a cada segundo no timer
        timerText.text = timer.ToString();
    }
}
