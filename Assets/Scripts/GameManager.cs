using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null; // need singleton for access from other classes
    public float curTargetDegree;
    public GameObject targetDot;
    public int totalSuccess;
    public int hitTime;
    private float timer;
    

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null){
            instance = this;
        } else if (instance != this){
            Destroy(gameObject);
        }
        GenerateTargetPosition();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateTargetPosition()
    {
        targetDot.SetActive(false);
        float angle;
        angle = 180*Random.value;
        if (Random.value < 0.5){
            angle *= -1;
        }
        targetDot.transform.rotation = Quaternion.Euler(0,0,angle);
        targetDot.SetActive(true);
    }

}
