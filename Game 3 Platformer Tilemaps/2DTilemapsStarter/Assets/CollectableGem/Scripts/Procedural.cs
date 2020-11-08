using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class Procedural : MonoBehaviour {
	public Tilemap Ground;
	public Tilemap Obiecte;
	public int width1;
	public int height1;
	public TileBase prop;
	public TileBase tile1;
	public int[,] harta;
	public float seed ;
	public int interval;

	// Use this for initialization
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.N))
		{
			ClearMap();
			GenerateMap();
		}
	}

	public void GenerateMap()
	{
		ClearMap();
		int[,] harta = new int[width1, height1];
		
		harta = RenderMap.GenerateArray(width1, height1, true);
				//Next generate the smoothed random top
				harta = RenderMap.RandomWalkTopSmoothed(harta, seed,interval);
				
		//Render the result

		RenderMap.RenderMap1(harta, Ground, tile1);
		RenderMap.RenderMapProps(harta,Obiecte,prop);
	}
	public void ClearMap()
	{
		Ground.ClearAllTiles();
		
		
	}
	
}
