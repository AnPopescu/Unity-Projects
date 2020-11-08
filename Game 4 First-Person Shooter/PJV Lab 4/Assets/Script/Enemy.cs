
using UnityEngine;
using UnityEngine.UI;
public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public float Health = 100f;
    public static float HPBandit = 100f;
    public  GameObject deathProp ;
    public GameObject slider;


    public void TakeDamage(float amount)
    {
        Health-=amount;
        HPBandit -=amount;
        if(Health<=0f)
        {
            Die();
        }
    }

    void Die()
    {   KillCount.killCounter++;
        HPBandit = 100f;
        Destroy(gameObject);
        Instantiate(deathProp,transform.position,transform.rotation);
    }
    



    public void ActivateSklider(){

        slider.SetActive(true);
    }
    public void DeactivateSlider(){
        slider.SetActive(false);
    }
}
