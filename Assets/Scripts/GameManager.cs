using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    Animator animator;
    public static GameManager instance = null; // need singleton for access from other classes
    public float curTargetDegree;
    public GameObject targetDot;
    private bool isScoreActive;
    public int points;
    public static Text scoreText;
    

    // Start is called before the first frame update
    void Start()
    {
        //animator = GetComponent<Animator>();
        curTargetDegree = 0;
        points = 0;
        if (instance == null){
            instance = this;
        } else if (instance != this){
            Destroy(gameObject);
        }
        scoreText = GameObject.Find("Score").GetComponent<Text>();
        isScoreActive = true;
        SetScoreActiveToggle();
        GenerateTargetPosition();
    }

    // Update is called once per frame
    void Update()
    {
        // potentially could include a levelUp feature
        /*if (points % 10 == 0 && !curUsed.Contains(points/10))
        {
            curUsed.Add(points / 10);
            animator.SetTrigger("NewLevel");
        }*/
    }

    // generates a new position for the target after a successful hit
    public void GenerateTargetPosition()
    {
        // update the point count in the UI
        scoreText.text = "" + points;

        targetDot.SetActive(false);
        float angle;
        
        // give some randomness to how new positions are selected
        angle = 180*Random.value;
        if (Random.value < 0.5){
            angle *= -1;
        }
        // this is to ensure that the target's new position is not next to its previous position
        if (Math.Abs(angle - curTargetDegree) < 30)
        {
            angle -= 60;
        }
        

        targetDot.transform.rotation = Quaternion.Euler(0,0,angle);
        curTargetDegree = angle;
        targetDot.SetActive(true);
    }

    // toggles the score display if game has not started yet
    public void SetScoreActiveToggle(){
        scoreText.text = "" + 0;
        if (!isScoreActive){
            scoreText.gameObject.SetActive(true);
            isScoreActive = true;
        } else {
            scoreText.gameObject.SetActive(false);
            isScoreActive = false;
        }
    }
    /* private float GenerateTargetAngle()
    {
        float dirMod = 1;
        if (Random.value < 0.5){
            dirMod *= -1;
        }
        float angle = curTargetDegree;
        while ((angle <= curTargetDegree+30 && angle >= curTargetDegree-30) || (curTargetDegree <= -150 && (angle < -150))
        {
            angle = 
        }
    } */
}
