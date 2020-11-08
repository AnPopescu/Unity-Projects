using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{   public float speed = 20f;
    public int damage = 20;
public Rigidbody2D rb;
    public GameObject impactEff;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }
    void OnTriggerEnter2D(Collider2D hiitInfo){
        Enemy enemy = hiitInfo.GetComponent<Enemy>();
        if(enemy!=null)
        {
            enemy.TakeDamage(damage);
        }
        Instantiate(impactEff,transform.position,transform.rotation);
        Destroy(gameObject);
        
        
    }

    // Update is called once per frame
   
}
