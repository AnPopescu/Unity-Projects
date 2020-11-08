using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//Every object has CharacterCombat and Caracterstats
[RequireComponent(typeof(CaracterStats))]

public class CharacterCombat : MonoBehaviour
{   private CaracterStats myStats;
    public float attackSpeed = 1f;
    private float attackCooldown = 0f;
    public float attackdelay = .6f;
    public event System.Action OnAttack;
    float PlayerDamageAAAAA;

    void Start()
    {
        myStats = GetComponent<CaracterStats>();
    }
    void Update()
    {
        attackCooldown -=Time.deltaTime;
    }
   public void Attack(CaracterStats targetStats)
   {    PlayerDamageAAAAA = myStats.damage.getValue();
    if(attackCooldown<=0)
    {
        StartCoroutine(DoDamage(targetStats,attackdelay));
        if(OnAttack != null)
        {
            OnAttack();
        }
        attackCooldown = 1f/attackSpeed;
    }
       
   }
   IEnumerator DoDamage(CaracterStats stats , float delay)
   {
       yield return new WaitForSeconds(delay);
       stats.TakeDamage(myStats.damage.getValue());
   }
}
