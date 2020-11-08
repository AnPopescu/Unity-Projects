using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ContextMenuGenerate :MonoBehaviour
{
   [MenuItem("CONTEXT/P_Grid/GenerateGrid")]

   static void ScaleUniform(MenuCommand command)
   {
      P_Grid func = (P_Grid)command.context;
      int xC = func.gridX;
      int yC = func.gridY;
      GameObject cube = func.itemToGen;
      float distance = func.distanceSpace;
      Vector3 origin = func.gridOrigin;
       for(int x = 0 ; x<xC; x++)
        {
                for (int z =  0;z<yC;z++)
                {
                    Vector3 spawnPosition = new Vector3(x*distance,0,z*distance);
                    Instantiate(cube,spawnPosition,Quaternion.identity);
                }
        }
   }

}

    

