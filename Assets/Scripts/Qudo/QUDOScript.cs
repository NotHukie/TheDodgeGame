using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QUDOSDK;
using UnityEngine.SceneManagement;

public class QUDOScript : MonoBehaviour
{
    bool isItPaused;
    bool isItPausedLvl;
    private void Update()
    {
        Scene scene = SceneManager.GetActiveScene();


        if (scene.name == "Survive")
        {
            GameObject player;

            player = GameObject.Find("PlayerSurvive");
            isItPaused = player.GetComponent<PlayerMovement>().isPaused;
        }

        if (scene.name == "LVL 2"||
            scene.name == "LVL 3")
        {
            GameObject playerLvl;

            playerLvl = GameObject.Find("PlayerL");
            isItPausedLvl = playerLvl.GetComponent<PlayerMovementLvl1>().isPaused;
        }
        if (scene.name == "Survive" && isItPaused == false ||
            scene.name == "LVL 2" && isItPausedLvl == false ||
            scene.name == "LVL 3" && isItPausedLvl == false)
        {
            StartActivity();
        }

        else
        {
            EndActivity();
            Debug.Log("2");
        }

        print(QUDO.CurrentGameState);
    }
    public void StartActivity()
    {
        QUDO.CurrentGameState = GameState.PLAYING;
    }
    public void EndActivity()
    {
        QUDO.CurrentGameState = GameState.IDLE;
    }
}

