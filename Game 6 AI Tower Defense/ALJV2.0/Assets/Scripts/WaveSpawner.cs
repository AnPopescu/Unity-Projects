using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
   
    public Text waveCountDownText;

    public Text ConstructionTimeText;

    public int waveFinal = 5;
    private int waveNR = 0;
    private bool roundEND= true;
    public float timeBetweenWaves = 50f;
    private float countdown = 2f;

    public float constructionTime = 15f;
    private int waveNumber=2;

    public GameObject shop;

    public GameObject STARTblock;
    SpawnerBun spawn;
    BlockState valueAI;




    void Start()
    {       valueAI = gameObject.GetComponent<BlockState>();
            spawn = STARTblock.GetComponent<SpawnerBun>();
            valueAI.generateVI();
    }
    void Update()
    {   
        if( roundEND == false)
        {   shop.SetActive(false);
        if(GameObject.FindGameObjectsWithTag("Enemy").Length ==0)
        {       waveNR ++;
                StartCoroutine(SpawnWave());
                countdown = timeBetweenWaves;
                
        }
        countdown-= Time.deltaTime;
        waveCountDownText.text ="Wave "+ waveNR;

        } else if(roundEND == true && GameObject.FindGameObjectsWithTag("Enemy").Length ==0)
        {   
            shop.SetActive(true);
            waveCountDownText.text = "Construction Time: "+ Mathf.Round(constructionTime).ToString();
            if(constructionTime<=0f)
            {
                roundEND = false;
                constructionTime = 15f;
                valueAI.generateVI();

            }
        constructionTime-=Time.deltaTime;
        
        }



    }




    IEnumerator SpawnWave(){
        
        
        for(int i=0;i<waveNumber;i++)
        {   
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
        waveNumber *= 2;

       

        roundEND = true;

    }


    void SpawnEnemy(){
        spawn.spawnOBJ();
    }
}
