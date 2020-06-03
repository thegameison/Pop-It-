using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null; // need singleton for access from other classes
    public float curTargetDegree;
    public GameObject targetDot;
    public int points;
    private Text scoreText;
    

    // Start is called before the first frame update
    void Start()
    {
        curTargetDegree = 0;
        points = 0;
        if (instance == null){
            instance = this;
        } else if (instance != this){
            Destroy(gameObject);
        }
        scoreText = GameObject.Find("Score").GetComponent<Text>();
        GenerateTargetPosition();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateTargetPosition()
    {
        scoreText.text = "Score: " + points;
        targetDot.SetActive(false);
        float angle;
        angle = 180*Random.value;
        if (Random.value < 0.5){
            angle *= -1;
        }
        targetDot.transform.rotation = Quaternion.Euler(0,0,angle);
        curTargetDegree = angle;
        targetDot.SetActive(true);
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
