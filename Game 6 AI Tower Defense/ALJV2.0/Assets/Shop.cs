using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }
   public void PurchaseStandardTurret ()
   {
       Debug.Log("Standard Turret purchased");
       buildManager.SetTurretToBuild(buildManager.standardTurret);
   }


   public void PurchaseMissleTurret ()
   {
       Debug.Log("Another Turret purchased");
       buildManager.SetTurretToBuild(buildManager.missleTurret);
   }
}
