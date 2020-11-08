using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveIT : MonoBehaviour
{
    
    private Vector3 direction;
    //public float speed;
    private int index;
   //public float speed = 10.0f;

     public float Speed = 0.1f;
    public float Starttomove = 2f;

    
    private Vector3 up = new Vector3(0,0,1);
    private Vector3 left = new Vector3(-1,0,0);
    private Vector3 down = new Vector3(0,0,-1);
    private Vector3 right = new Vector3(1,0,0);

    private Vector3 finalDir = new Vector3(0,0,0);

    public Image healthBar;
    public int health = 100;


    public void TakeDamage(int amount)
    {
        health-=amount;
        Debug.Log(health + "HEalth");
        Debug.Log(amount + "DMG");
        healthBar.fillAmount =  health/100f;
        if(health<=0)
        {
            Die();
        }
    }


    void Start()
    {   
        index = 0;
        direction = BlockState.points[index];
    }

    void Update()
    {
        //transform.position = transform.position + direction * speed *Time.deltaTime;
         if(Starttomove <=0f)
        {
                
                Starttomove = Speed;
                transform.Translate(direction,Space.World); 
                setNextDir();
                
        }
        Starttomove-= Time.deltaTime;
        
    }

    void setNextDir()
    {     
        if(BlockState.points[index+1]!= finalDir){
            index++;
            direction = BlockState.points[index];
            
           if(direction !=  BlockState.points[index-1]){

           
            if(direction == up )      transform.Rotate(new Vector3(0,90,0),Space.Self);
           if(direction == left)      transform.Rotate(new Vector3(0,-90,0),Space.Self);
           if(direction == down)      transform.Rotate(new Vector3(0,-90,0),Space.Self);
            if(direction == right)     transform.Rotate(new Vector3(0,90,0),Space.Self);
           }
            }
            else Destroy(gameObject);
        
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
