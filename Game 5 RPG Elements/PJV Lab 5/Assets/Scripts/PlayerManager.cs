using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    #region Singleton

    public static PlayerManager instance;
    void Awake()
    {
        instance = this;
    }
   

    #endregion
    public GameObject player;
    public GameObject tombstone;
     public void KillPlayer()
    {   Debug.Log("PlayerWasKilled");
     Vector3 placePOS = new Vector3 (player.transform.position.x+2f,-2.7f,player.transform.position.z);
        Instantiate(tombstone,placePOS,Quaternion.identity);
        Destroy(player);
    }
}
