using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class TargetBehavior : MonoBehaviour
{

    private CircleCollider2D collision;
    private float timer;
    private float timer2 = 0;
    private bool isTouching;
    public float contactReq;
    // Start is called before the first frame update
    private AudioSource source;
    private Text bonus;
    void Start()
    {
      
        collision = GetComponent<CircleCollider2D>();
        timer = 0;
        isTouching = false;
        source = GetComponent<AudioSource>();
        bonus = GameObject.Find("Bonus").GetComponent<Text>();
        bonus.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (bonus.gameObject.activeSelf)
        {
            if (timer2 >= 1)
            {
                bonus.gameObject.GetComponent<AudioSource>().Stop();
                bonus.gameObject.SetActive(false);
                timer2 = 0;
            } else 
            {
                timer2 += Time.deltaTime;
            }
        }
    }
    private void OnTriggerStay2D(Collider2D other) 
    {
        //print("I'm in");
        isTouching = true;
        timer += Time.deltaTime;
        //print("Time is "+ timer);
        
        
        
        if (isTouching && (timer >= contactReq)){
            //print("We switching");
            if (ButtonHandler.isStart == true)
            {
                GameManager.instance.points++;
            }
                
            source.Play();
            TimerHandler.timeRemaining += contactReq;
            CalculateTimeBonus();
            GameManager.instance.GenerateTargetPosition();
         
            timer = 0;
            isTouching = false;
        }

        
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        //print("we out");
        timer = 0;
        isTouching = false;
    }

    private void CalculateTimeBonus()
    {
        float rng = Random.value;
        if((2/(float) GameManager.instance.points) > rng)
        {
            TimerHandler.timeRemaining++;
            bonus.gameObject.SetActive(true);
            bonus.gameObject.GetComponent<AudioSource>().Play();
        }
    }
}
