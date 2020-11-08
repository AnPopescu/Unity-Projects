using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    private Transform target;
    public float speed = 70f;
    public float explosionRadius =0;
    public float distanceThisFrame;
    public GameObject impactEffect;
    public int damage = 50;

    public void Chase(Transform _target)
    {
        target = _target;
    }

    void Update()
    {   
        if(target==null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        distanceThisFrame = speed *Time.deltaTime;
    

        if(dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            
            return;
        }

        transform.Translate(dir.normalized*distanceThisFrame,Space.World);
        transform.LookAt(target);




    }

    void HitTarget()
    {   GameObject effectINS =(GameObject)Instantiate(impactEffect,transform.position,transform.rotation);
    Destroy(effectINS,2f);
    if(explosionRadius>0f)
    {
        Explode();
    }else
    {
        Damage(target);
    }
      
        
        Destroy(gameObject);
    }

    void Explode()
    {
        Collider[] coliders = Physics.OverlapSphere(transform.position,explosionRadius);
        foreach (Collider collider in coliders)
        {
            if(collider.tag=="Enemy")
            {
                Damage(collider.transform);
            }
        }
    }

    void Damage(Transform enemy)
    {   
        MoveIT e = enemy.GetComponent<MoveIT>();
        if(e!=null)
        {
        e.TakeDamage(damage);
        }
        //Destroy(enemy.gameObject);
    }

    void OnDrawGizmosSelected()
    {   
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,explosionRadius);
    }

}
