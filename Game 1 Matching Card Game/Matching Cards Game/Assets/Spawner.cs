using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform SpawnPos;
    public GameObject spawnee;

    private Vector3[] pos;
    void Start()
    {   for(int i=0 ;i<4;i++)
            {   pos[i].x =  (i-100)*2;
                for(int j=0;j<=4;j++)
                {
                    pos[j].y =(j-100)*2;
                }

            }
            for(int k=0;k<4;k++){
                for(int r =0;r<=3;r++)
                {
//                    Instantiate(spawnee,SpawnPos.pos[1]);
                }
            }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
