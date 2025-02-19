using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public Text scoreText;
    public Text highscoreText;
    public static ScoreManager instance = null;

    public float score = 0;
    public float highscore = 0;
    [SerializeField] float pointIncreasedPerSecond;
    public bool isRunning;

    void Start()
    {
        highscore = PlayerPrefs.GetFloat("highscore", 0);
        scoreText.text = "SCORE: " + score.ToString();
        highscoreText.text = "HIGHSCORE: " + highscore.ToString();
        highscoreText.text = "HIGHSCORE: " + (int)ScoreManager.instance.highscore;

        isRunning = true;
    }
    private void Awake()
    {
        instance = this;
    }
    void Update()
    {
        if (isRunning)
        {
            score += pointIncreasedPerSecond * Time.deltaTime;
            scoreText.text = "SCORE: " + score.ToString();
            scoreText.text = "Score " + (int)ScoreManager.instance.score;
            
        }
        if(highscore < score)
        {
            PlayerPrefs.SetFloat("highscore", score);
            highscoreText.text = "HIGHSCORE: " + (int)ScoreManager.instance.score;
        }
    }

}
