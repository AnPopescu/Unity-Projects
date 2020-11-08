using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RenderMap : MonoBehaviour {

        

 public static int[,] GenerateArray(int width, int height, bool empty)
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

public static int[,] RandomWalkTopSmoothed(int[,] map, float seed, int minSectionWidth)
    {
        //Seed our random
        System.Random rand = new System.Random(seed.GetHashCode());

        //Determine the start position
        int lastHeight = Random.Range(0, map.GetUpperBound(1));

        //Used to determine which direction to go
        int nextMove = 0;
        //Used to keep track of the current sections width
        int sectionWidth = 0;

        //Work through the array width
        for (int x = 0; x <= map.GetUpperBound(0); x++)
        {
            //Determine the next move
            nextMove = rand.Next(2);

            //Only change the height if we have used the current height more than the minimum required section width
            if (nextMove == 0 && lastHeight > 0 && sectionWidth > minSectionWidth)
            {
                lastHeight--;
                sectionWidth = 0;
            }
            else if (nextMove == 1 && lastHeight < map.GetUpperBound(1) && sectionWidth > minSectionWidth)
            {
                lastHeight++;
                sectionWidth = 0;
            }
            //Increment the section width
            sectionWidth++;

            //Work our way from the height down to 0
            for (int y = lastHeight; y >= 0; y--)
            {
                map[x, y] = 1;
            }
        }

        //Return the modified map
        return map;
    }

public static void RenderMap1(int[,] map, Tilemap tilemap, TileBase tile)
    {
        tilemap.ClearAllTiles(); //Clear the map (ensures we dont overlap)
        for (int x = 0; x < map.GetUpperBound(0) ; x++) //Loop through the width of the map
        {       
            for (int y = 0; y < map.GetUpperBound(1); y++) //Loop through the height of the map
            {   

                // if(y==(map.GetUpperBound(1)-1)&&map[x, y] == 1)
                // {         Debug.Log("Deseneaza la"+x +y);
                //         
                // }
               

                if (map[x, y] == 1) // 1 = tile, 0 = no tile
                {
                    tilemap.SetTile(new Vector3Int(x, y, 0), tile); 
                }
            }
        }
    }
    public static void RenderMapProps(int[,] map, Tilemap tilemap, TileBase tile)
    {
        tilemap.ClearAllTiles(); //Clear the map (ensures we dont overlap)
        for (int x = 0; x < map.GetUpperBound(0) ; x++) //Loop through the width of the map
        {       
            for (int y = 0; y < map.GetUpperBound(1); y++) //Loop through the height of the map
            {   

                // if(y==(map.GetUpperBound(1)-1)&&map[x, y] == 1)
                // {         Debug.Log("Deseneaza la"+x +y);
                //         
                // }
                if(map[x,y+1]==0&&map[x,y]==1) {
                     
                    tilemap.SetTile(new Vector3Int(x, y+1, 0), tile);
                   // Debug.Log("Deseneaza la :"+x+y+1);
                }

               
            }
        }
    }


}