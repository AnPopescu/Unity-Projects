using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{    private GameObject turretToBuild;
    public GameObject standardTurret;
    public static BuildManager instance;
    public GameObject missleTurret;
    void Awake(){
        if(instance!=null)
        {
            Debug.LogError("More than one BuildManager in scene");
            return;
        }
        instance = this;
        
    }
    

    public void SetTurretToBuild(GameObject turret)
    {
        turretToBuild = turret;
    }

  

   public GameObject GetTurretToBuild()
   {
       return turretToBuild;
   }
}
