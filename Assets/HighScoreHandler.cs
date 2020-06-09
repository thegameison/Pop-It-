using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreHandler : MonoBehaviour
{
    public static Text highScoreText;
    public static int highScore;
    // Start is called before the first frame update
    void Start()
    {
        highScore = 0;
        highScoreText = gameObject.GetComponent<Text>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void updateScore(int newScore)
    {
        if(newScore > highScore)
        {
            highScore = newScore;
            highScoreText.text = "High Score: " + newScore.ToString();
        }
    }
}
