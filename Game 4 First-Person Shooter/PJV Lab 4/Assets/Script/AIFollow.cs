using UnityEngine;
using System.Collections;
 
public class AIFollow : MonoBehaviour {
   
    //The target player
 public Transform player;
 //At what distance will the enemy walk towards the player?
 public float walkingDistance = 10.0f;
 //In what time will the enemy complete the journey between its position and the players position
 public float smoothTime = 10.0f;
 //Vector3 used to store the velocity of the enemy
 private Vector3 smoothVelocity = Vector3.zero;
 public float banditDMG = 15f;

 public float hitDistance = 5f;

 public float movementSpeed = 12f;
 private AudioSource BDSource;
 private bool didPlay = false;
 //Call every frame
    void Awake() {
      
    }
   
    // Use this for initialization
    void Start () {
    
        BDSource = GetComponent<AudioSource>();
    }
   
    // Update is called once per frame
    void Update () {
        
        Vector3 pos = transform.position;
     float x = transform.localScale.y/4;
     transform.position = new Vector3(pos.x,Terrain.activeTerrain.SampleHeight(pos)+(x),pos.z);
        transform.Rotate(-90, 0, 0);

      transform.LookAt(player);
     //Calculate distance between player
     float distance = Vector3.Distance(transform.position, player.position);
     //If the distance is smaller than the walkingDistance
     if(distance < walkingDistance && didPlay == false)
     {
         BDSource.Play();
         didPlay = true;
     }
     if(distance < walkingDistance && distance > 3f)
     {      GetComponent<ButtonFunction>().Walk();
        

           
         //Move the enemy towards the player with smoothdamp
        //transform.position = Vector3.MoveTowards(transform.position, player.position, walkingDistance);
        transform.position += transform.forward * movementSpeed * Time.deltaTime;
     } else  GetComponent<ButtonFunction>().Idle();
    }
    void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<PlayerHP>().plTakeDmg(banditDMG);
    }
}
