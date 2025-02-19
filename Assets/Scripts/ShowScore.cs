using UnityEngine;
using UnityEngine.UI;

public class ShowScore : MonoBehaviour
{
    public Text scoreText;
    public Text highScoreText;
    void Start()
    {
        scoreText.text = "Score " + (int)ScoreManager.instance.score;
        highScoreText.text = "Highscore " + (int)ScoreManager.instance.highscore;

    }
    private void Update()
    {
        if ((int)ScoreManager.instance.score > (int)ScoreManager.instance.highscore)
        {
            highScoreText.text = "Highscore " + (int)ScoreManager.instance.score;
        }
    }
}
