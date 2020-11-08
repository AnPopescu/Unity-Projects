using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateArray : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	// Update is called once per frame
	void Update () {
		
	}
		public static int[,] GenerateArray1(int width, int height, bool empty)
		{
    int[,] map = new int[width, height];
    for (int x = 0; x < map.GetUpperBound(0); x++)
    {
        for (int y = 0; y < map.GetUpperBound(1); y++)
        {
            if (empty)
            {
                map[x, y] = 0;
            }
            else
            {
                map[x, y] = 1;
            }
        }
    }
    return map;
		}
	


	
}
