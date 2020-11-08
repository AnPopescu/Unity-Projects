using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{   public static float HP = 100f;
    public GameObject deathProp;
    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnPoint;
    public void plTakeDmg(float damage)
    {   Debug.Log("Recived "+damage);
        HP -= damage;
        if(HP <= 0f)
        {
            Death();
        }
    }

    
    void Death()
    {
        HP = 100f;
        //Instantiate(deathProp,transform.position,transform.rotation);
        player.transform.position = respawnPoint.transform.position;
        

    }
}
