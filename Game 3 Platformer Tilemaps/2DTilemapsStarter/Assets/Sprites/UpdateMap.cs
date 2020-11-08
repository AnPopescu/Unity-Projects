using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class UpdateMap : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
			
	}

	public static void UpdateMap1(int[,] map, Tilemap tilemap) //Takes in our map and tilemap, setting null tiles where needed
	{
    for (int x = 0; x < map.GetUpperBound(0); x++)
    {
        for (int y = 0; y < map.GetUpperBound(1); y++)
        {
            //We are only going to update the map, rather than rendering again
            //This is because it uses less resources to update tiles to null
            //As opposed to re-drawing every single tile (and collision data)
            if (map[x, y] == 0)
            {
                tilemap.SetTile(new Vector3Int(x, y, 0), null);
            }
        }
    }
	}	
}
