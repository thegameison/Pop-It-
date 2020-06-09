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
    //public HashSet<int> curUsed = new HashSet<int>();
    

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
        /*if (points % 10 == 0 && !curUsed.Contains(points/10))
        {
            curUsed.Add(points / 10);
            animator.SetTrigger("NewLevel");
        }*/
    }

    public void GenerateTargetPosition()
    {
        scoreText.text = "" + points;
        targetDot.SetActive(false);
        float angle;
        angle = 180*Random.value;
        if (Random.value < 0.5){
            angle *= -1;
        }
        if (Math.Abs(angle - curTargetDegree) < 30)
        {
            angle -= 60;
        }
        targetDot.transform.rotation = Quaternion.Euler(0,0,angle);
        curTargetDegree = angle;
        targetDot.SetActive(true);
    }
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
