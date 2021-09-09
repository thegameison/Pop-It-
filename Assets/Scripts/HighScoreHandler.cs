using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreHandler : MonoBehaviour
{
    public static Text highScoreText;
    public static Text gameOver;
    public static Text finalScore;
    public static int highScore;

    // Start is called before the first frame update
    void Start()
    {
        highScore = PlayerPrefs.GetInt("highscore");
        highScoreText = gameObject.GetComponent<Text>();
        highScoreText.text = "High Score: " + highScore;
        gameOver = GameObject.Find("GameOver").GetComponent<Text>();
        gameOver.gameObject.SetActive(false);
        finalScore = GameObject.Find("FinalScore").GetComponent<Text>();
        finalScore.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // update the high score at the end of the each game
    public static void updateScore(int newScore)
    {
        gameOver.gameObject.SetActive(true);
        gameOver.gameObject.GetComponent<AudioSource>().Play();
        finalScore.gameObject.SetActive(true);
        finalScore.text = "Final Score: " + newScore;        
        if(newScore > highScore)
        {
            PlayerPrefs.SetInt("highscore", newScore);
            highScore = newScore;
            highScoreText.text = "High Score: " + newScore.ToString();
        }
    }

    // when a new game starts, disable the gameover text
    public static void DisableGameOver()
    {
        gameOver.gameObject.SetActive(false);
        finalScore.gameObject.SetActive(false);
    }
}
