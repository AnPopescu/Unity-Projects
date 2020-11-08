using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class GeneratePrefabs : MonoBehaviour
{   
    [MenuItem("CONTEXT/RecreateToPrefab/GenPrefabs")]
   static void ScaleUniform(MenuCommand command)
   {
      RecreateToPrefab func = (RecreateToPrefab)command.context;

      GameObject prefab = func.prefab;
      GameObject[] lista = func.list;
      Transform[] poz = func.place;

      for(int i = 0;i<=lista.Length;i++)
      {
          Instantiate(prefab,lista[i].transform.position,lista[i].transform.rotation);
      }

   }

    
  
}
