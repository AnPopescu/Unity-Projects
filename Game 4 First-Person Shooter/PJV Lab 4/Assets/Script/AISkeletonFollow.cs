using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISkeletonFollow : MonoBehaviour
   {
    //The target player
 public Transform player;
 //At what distance will the enemy walk towards the player?
 public float walkingDistance = 90.0f;
 public AudioSource SkSource;
 
public AudioClip Enrage;
 
 public float skeletDmg = 35f;

 public float movementSpeed = 14f;
 private int animationSW = 0;
 private bool didPlay = false;

 //Call every frame
    void Awake() {
      
    }
   
    // Use this for initialization
    void Start () {
        
        SkSource = GetComponent<AudioSource>();

   
    }
   
    // Update is called once per frame
    void Update () {
        
        switch(animationSW)
        {
            case 0 : GetComponent<SKanimations>().skIdle(); break;
            case 1 : GetComponent<SKanimations>().skWalk(); break;
            case 2 : GetComponent<SKanimations>().skRun(); break;
            case 3 : GetComponent<SKanimations>().skAttack(); break;




        }
        Vector3 pos = transform.position;
     float x = transform.localScale.y/16;
     transform.position = new Vector3(pos.x,Terrain.activeTerrain.SampleHeight(pos)+(x-1),pos.z);
        //transform.Rotate(-90, 0, 0);

      transform.LookAt(player);
     //Calculate distance between player
     float distance = Vector3.Distance(transform.position, player.position);
     //If the distance is smaller than the walkingDistance
     if(distance < walkingDistance && didPlay == false)
     {
         SkSource.Play();
         didPlay = true;
     }
     if(distance < walkingDistance && distance > 5f)
     {      animationSW = 2;
            
                
           
         //Move the enemy towards the player with smoothdamp
        //transform.position = Vector3.MoveTowards(transform.position, player.position, walkingDistance);
        transform.position += transform.forward * movementSpeed * Time.deltaTime;
     } else if(distance < 5f)
                {
                    animationSW = 3;
                }else animationSW = 0;
     
    }
     void OnTriggerEnter(Collider other)
     {
         other.gameObject.GetComponent<PlayerHP>().plTakeDmg(skeletDmg);
     }
}
