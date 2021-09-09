using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    public static bool isStart = false;
    public static Button b;

    // Start is called before the first frame update
    void Start()
    {
        b = gameObject.GetComponent<Button>();
        b.onClick.AddListener(ButtonClicked);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // click the button to start the game
    void ButtonClicked()
    {
        isStart = true;
        HighScoreHandler.DisableGameOver();
        b.gameObject.SetActive(false);
        TimerHandler.upStart();
        GameManager.instance.SetScoreActiveToggle();
        TimerHandler.textTimer.gameObject.SetActive(true);
    }
}
