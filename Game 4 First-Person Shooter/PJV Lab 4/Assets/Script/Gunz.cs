
using UnityEngine;
using System.Collections;

public class Gunz : MonoBehaviour
{
    public float dmg = 10f;
    public float range = 100f;
    public ParticleSystem muzzleFlash;
    public Camera fpsCam;
    public float fireRate = 15f;

    public GameObject impactEffect;
    public float impactForce = 30f;
    private float nextTimeToFire = 0f;
    public int maxAmmo = 30;
    public static int currentAmmo = 30;
    public float reloadTime = 1f;
    public static bool isreloading = false;
    private AudioSource gunShoot;


    void Start()
    {
        currentAmmo = maxAmmo;
        gunShoot = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {   if(isreloading)
           return;
           
        if(currentAmmo<=0)
        {
            StartCoroutine(Reload());
            return;
        }
        if(Input.GetButton("Fire1")&&Time.time>=nextTimeToFire){
            nextTimeToFire = Time.time +1f/fireRate;
            Shoot();
        }
        if(Input.GetButtonDown("Reload"))
        {
            StartCoroutine(Reload());
            return;
        }
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position,fpsCam.transform.forward,out hit,range))
        {   
            Enemy enemyHP = hit.transform.GetComponent<Enemy>();
            EnemySkeleton enemy1HP = hit.transform.GetComponent<EnemySkeleton>();
            if(enemyHP != null )
            {
                enemyHP.ActivateSklider();
                
            }//else   enemyHP.DeactivateSlider();

            if(enemy1HP!=null){
            enemy1HP.ActivateSklider();
            Debug.Log("Activate");
            }   //else {enemy1HP.DeactivateSlider();
                           // Debug.Log("Deactivate");
//}

        } 
        

    }
    void Shoot()
    {   muzzleFlash.Play();
        currentAmmo--;
        gunShoot.Play();
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position,fpsCam.transform.forward,out hit,range))
        {   
            Enemy enemy = hit.transform.GetComponent<Enemy>();
            EnemySkeleton enemy1 = hit.transform.GetComponent<EnemySkeleton>();
            if(enemy != null )
            {
                enemy.TakeDamage(dmg);
                
            }
            if(enemy1!=null){
            enemy1.TakeDamage(dmg);
            }
            if (hit.rigidbody!=null)
            {
                  hit.rigidbody.AddForce(-hit.normal*impactForce);  
            }
            GameObject impactGO = Instantiate(impactEffect,hit.point,Quaternion.LookRotation(hit.normal));
            Destroy(impactGO,1f);

            Debug.Log(hit.transform.name);
        }


    }
    IEnumerator Reload()
    {   Debug.Log("Reloading..");
        isreloading = true;
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;
        isreloading = false;

    }
}
