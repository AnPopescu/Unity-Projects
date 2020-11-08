using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CaracterStats
{
    public override void Die()
    {
        base.Die();

        // add death animation
        Destroy(gameObject);
    }
}
