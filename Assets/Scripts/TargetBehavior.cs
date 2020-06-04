using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBehavior : MonoBehaviour
{

    private CircleCollider2D collision;
    private float timer;
    private bool isTouching;
    public float contactReq;
    // Start is called before the first frame update
    void Start()
    {
      
        collision = GetComponent<CircleCollider2D>();
        timer = 0;
        isTouching = false;
    }

    // Update is called once per frame
    void Update()
    {
      
        // can leave blank I think, as this is only based on collisions
    }
    private void OnTriggerStay2D(Collider2D other) 
    {
        //print("I'm in");
        isTouching = true;
        timer += Time.deltaTime;
        //print("Time is "+ timer);
        
        
        
        if (isTouching && (timer >= contactReq)){
            //print("We switching");
            GameManager.instance.points++;            
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
}
