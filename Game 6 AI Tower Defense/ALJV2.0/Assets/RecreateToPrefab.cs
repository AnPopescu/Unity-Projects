using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecreateToPrefab : MonoBehaviour
{   
    
    public GameObject prefab;
    public GameObject[] list;

    public Transform[] place;

    void GetTransf(){

    for(int i=0 ; i<list.Length;i++)
    {
            place[i].position = list[i].transform.position;
            place[i].rotation = list[i].transform.rotation;

    }

    }


}
