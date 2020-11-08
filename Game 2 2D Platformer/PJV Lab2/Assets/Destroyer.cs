using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Start(){ 
        StartCoroutine(KillEffect());
    }
    IEnumerator KillEffect() 
   {       
        
        yield return new WaitForSeconds(0.8f);
        Destroy(gameObject);
    }
   
}
