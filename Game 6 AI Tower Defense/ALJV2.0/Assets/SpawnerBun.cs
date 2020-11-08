using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBun : MonoBehaviour
{
    public GameObject objectToSpawn;
    public Vector3 offsetY = new Vector3 (0,-0.4f,0);

    public void spawnOBJ()
    {
        Instantiate(objectToSpawn,transform.position+offsetY,Quaternion.identity);
    }
}
