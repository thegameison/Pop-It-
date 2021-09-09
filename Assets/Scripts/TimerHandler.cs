using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerHandler : MonoBehaviour
{
    public static Text textTimer;
    public static float timeRemaining = 30;
    // Start is called before the first frame update
    void Start()
    {
        textTimer = gameObject.GetComponent<Text>();
        textTimer.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(timeRemaining > 0)
        {
            // keeps track of time remaining in this game
            timeRemaining -= Time.deltaTime;
            
            int curTimeLeft = (int)Math.Round(timeRemaining, 0);
            
            // different ways to display the time
            if (curTimeLeft >= 10)
            {
                textTimer.text = "0:"+curTimeLeft.ToString();
            }
            else
            {
                textTimer.text = "0:0" + curTimeLeft.ToString();
            }
            
        }
        else
        {
            // update high score using a static function
            HighScoreHandler.updateScore(GameManager.instance.points);
            // reset time and states of UI elements
            timeRemaining = 30;
            ButtonHandler.isStart = false;
            ButtonHandler.b.gameObject.SetActive(true);
            textTimer.gameObject.SetActive(false);
            GameManager.instance.SetScoreActiveToggle();
            GameManager.instance.points = 0;
            
        }
    }

    public static void upStart()
    {
        timeRemaining = 30;
    }
}
