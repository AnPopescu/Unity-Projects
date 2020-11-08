using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CaracterStats))]
public class Enemy : Interactable
{   PlayerManager playerManager;
    CaracterStats myStats;

    private Vector3 _goal;
    private Vector3 _startPoz;

    void Start()
    {
        playerManager = PlayerManager.instance;
        myStats = GetComponent<CaracterStats>();
    }
   public override void Interact()
   {
       base.Interact();
       //Attack
       CharacterCombat playerCombat = playerManager.player.GetComponent<CharacterCombat>();
       if(playerCombat!=null)
       {
           playerCombat.Attack(myStats);
       }

   }
}
