using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform target;
    [Header("Attributes")]
    public float firerate = 1f;
    private float fireCount = 0f;
    public float range = 15f;
    [Header("Unity Setup")]
    public string enemyTag ="Enemy";
    public Transform partToRotate;
    public float turnSpeed = 10f;

    public GameObject bulletPrefab;
    public Transform firePoint;
    

    void Start(){
        InvokeRepeating("UpdateTarget",0f,0.5f);
    }
    void Update(){
        if(target == null)
        {
            return;
        }
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotarion = Quaternion.LookRotation(dir);
        Vector3 roatation = Quaternion.Lerp(partToRotate.rotation,lookRotarion,Time.deltaTime*turnSpeed).eulerAngles; //Transforms quaternion into euler angles
        partToRotate.rotation = Quaternion.Euler(0f,roatation.y,0f);

        if(fireCount <= 0f)
        {
            shoot();
            fireCount = 1f/firerate;
        }
        fireCount -= Time.deltaTime;
    }

    void shoot(){
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab,firePoint.position,firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        if(bullet != null)
        {
            bullet.Chase(target);
        }
    }

    void OnDrawGizmosSelected()
    {   
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,range);
    }

    void UpdateTarget()
    {   
            GameObject[]  enemies = GameObject.FindGameObjectsWithTag(enemyTag);
            float shortestDistance = Mathf.Infinity;
            GameObject nearestEnemy = null;
            foreach(GameObject enemy in enemies)
            {
                float distanceToEnemy = Vector3.Distance(transform.position,enemy.transform.position);
                if(distanceToEnemy < shortestDistance){
                    shortestDistance = distanceToEnemy ;
                    nearestEnemy = enemy;
                }
            }

            if(nearestEnemy != null&& shortestDistance <= range)
            {
                target = nearestEnemy.transform;
            }else 
            {
                target = null;
            }

    }

}
