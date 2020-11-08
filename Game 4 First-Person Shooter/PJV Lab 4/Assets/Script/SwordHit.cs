using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordHit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public float skeletDmg = 15;
    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
     {
         other.gameObject.GetComponent<PlayerHP>().plTakeDmg(skeletDmg);
     }
}
