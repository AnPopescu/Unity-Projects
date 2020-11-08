using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
       public GameObject lizard;
       float randX;
       Vector2 wheretoSpawn;
       public float spawnRate = 2f;
       float nextSpawn = 0.0f;
    
    void Start()
    {  for(int i=1 ;i<=3;i++){
        randX = Random.Range (12.8f,50f);
        wheretoSpawn = new Vector2 (randX, transform.position.y);
        Instantiate ( lizard,wheretoSpawn,Quaternion.identity);
        }
        
    }

    
    void Update()
    {
      
    }
}
