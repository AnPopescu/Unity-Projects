using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public int speed = 1;
    public bool sw;
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {  
        
         
         if(sw)
    
            {   transform.localScale = new Vector2(-3.4f,3.4f);
        Vector3 right = new Vector3(1.0f,0.0f,0.0f);
        transform.position = transform.position + right *Time.deltaTime* speed;
            }else {     
            transform.localScale = new Vector2(3.4f,3.4f);

        Vector3 left = new Vector3(1.0f,0.0f,0.0f);
        transform.position = transform.position - left*Time.deltaTime*  speed;

                  }
        
    }
    void OnTriggerEnter2D(Collider2D other){

            if(other.gameObject.CompareTag("turn")){
                    if(sw) sw=false; else sw = true;

            }

    }



}