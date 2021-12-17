using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowScore : MonoBehaviour
{
    public Text scoreText;

    private void Start()
    {
        //Score score = GameConsole.GetComponent<Score>();
        //scoreText.text = "Score " + GameObject.Find("GameConsole").GetComponent<Score>().scoreAmount; //score.scoreAmount;
    }
}
