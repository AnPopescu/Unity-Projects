using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Grid : MonoBehaviour
{
    public GameObject itemToGen;
    public int gridX;
    public int gridY;
    public float distanceSpace;
    public Vector3 gridOrigin = Vector3.zero;

    void Start()
    {
        SpawnGrid();
    }

    void SpawnGrid()
    {
        for(int x = 0 ; x<gridX; x++)
        {
                for (int z =  0;z<gridY;z++)
                {
                    Vector3 spawnPosition = new Vector3(x*distanceSpace,0,z*distanceSpace);
                    Spawn(spawnPosition,Quaternion.identity);
                }
        }
    }
    void Spawn(Vector3 positionToSpawn,Quaternion rotationToSpawn)
    {
        GameObject clone = Instantiate(itemToGen,positionToSpawn,rotationToSpawn);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
