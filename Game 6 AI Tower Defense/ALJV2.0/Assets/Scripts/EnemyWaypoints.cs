using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaypoints : MonoBehaviour
{
   public float speed = 10;
   private Vector3 target;
   private int wavepointIndex = 0;

   void Start()
   {
       
   }
   void Update()
   {
       target = BlockState.points[wavepointIndex];
       transform.Translate(target*speed*Time.deltaTime);
        GetNextWaypoint();
    //    if(Vector3.Distance(transform.position,target.position)<=0.2f)
    //    {
    //        GetNextWaypoint();
    //    }
   }
   void GetNextWaypoint(){
       
       if(wavepointIndex>= 20)
       {
           Destroy(gameObject);
           return;
       }
       wavepointIndex++;
       target = BlockState.points[wavepointIndex];

   }
}
