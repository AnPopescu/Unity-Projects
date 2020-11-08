using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simple : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public static int[,] PerlinNoise(int[,] map, float seed)
	{
    int newPoint;
    //Used to reduced the position of the Perlin point
    float reduction = 0.5f;
    //Create the Perlin
    for (int x = 0; x < map.GetUpperBound(0); x++)
    {
        newPoint = Mathf.FloorToInt((Mathf.PerlinNoise(x, seed) - reduction) * map.GetUpperBound(1));

        //Make sure the noise starts near the halfway point of the height
        newPoint += (map.GetUpperBound(1) / 2); 
        for (int y = newPoint; y >= 0; y--)
        {
            map[x, y] = 1;
        }
    }
    return map;
	}





}




