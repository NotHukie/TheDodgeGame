using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowScore : MonoBehaviour
{
    public Text scoreText;

    private void Start()
    {
        scoreText.text = "Score " + (int)Score.instance.scoreAmount;
    }
}