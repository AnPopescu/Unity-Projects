using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerGems : MonoBehaviour
{
       public GameObject[] Gem;
       float randX;
       int randGem;
       public float posXplus;
       public float posXmin;
       //public float spawnRate = 2f;
       float nextSpawn = 0.0f;
       Vector2 wheretoSpawn;
       public int HowMany = 3;
    
    void Start()
    {  
        
    }
    void SpawnGems(){

        for(int i=1 ;i<=HowMany;i++){
        randX = Random.Range (posXmin,posXplus);
         randGem = Random.Range (0,Gem.Length);
            Debug.Log("GemNumber: "+randGem);
        wheretoSpawn = new Vector2 (randX, transform.position.y);
        Instantiate ( Gem[randGem],wheretoSpawn,Quaternion.identity);
        }

    }

    
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.G))
		{
			SpawnGems();
		}
    }
}
