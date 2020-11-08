
using UnityEngine;
using UnityEngine.UI;

public class EnemySkeleton : MonoBehaviour
{
    // Start is called before the first frame update
    public float Health = 150f;
    public static float HpforBar = 150f;
    public  GameObject deathProp ;
    
    public GameObject slider;



    public void ActivateSklider(){

        slider.SetActive(true);
    }
    public void DeactivateSlider(){
        slider.SetActive(false);
    }
        public void TakeDamage(float amount)
    {
        Health-=amount;
        HpforBar -= amount;
        GetComponent<SKanimations>().skDmg();
        if(Health<=0f)
        {
            Die();
        }
    }

    void Die()
    {   KillCount.killCounter++;
        HpforBar = 150f;
        Destroy(gameObject);
        Instantiate(deathProp,transform.position,transform.rotation);
        
    }
}
