using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform firePoint2;
    public GameObject bulletPrefab2;
    // Update is called once per frame
    void Update()
    {
        StartCoroutine(AutoShoot());
    }

    void Shoot2(){

            Instantiate(bulletPrefab2, firePoint2.position,firePoint2.rotation);

    }

      IEnumerator AutoShoot() 
   {       
        
        yield return new WaitForSeconds(2);
        Shoot2();
    }
}
