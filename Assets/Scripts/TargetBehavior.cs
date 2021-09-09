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
      
        // 
        collision = GetComponent<CircleCollider2D>();
        timer = 0;
        isTouching = false;
        source = GetComponent<AudioSource>();
        // bonus points target
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
        // means the cursor is touching the trigger
        isTouching = true;
        timer += Time.deltaTime;
        
        
        // makes sure cursor stays on the target for at least a certain amount of time
        if (isTouching && (timer >= contactReq)){

            // only increases score if the game has started
            if (ButtonHandler.isStart == true)
            {
                GameManager.instance.points++;
            }
            // plays a sound    
            source.Play();
            
            // makes sure that if the update function is too slow, then player is not penalized
            TimerHandler.timeRemaining += contactReq;
            CalculateTimeBonus();

            // select a new position for the target
            GameManager.instance.GenerateTargetPosition();
         
            timer = 0;
            isTouching = false;
        }

        
    }

    private void OnTriggerExit2D(Collider2D other) 
    {

        timer = 0;
        isTouching = false;
    }

    // player has a random chance for extra time (chances decrease as they accumulate more points)
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
