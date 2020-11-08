using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GroundNODE : MonoBehaviour
{   
    public Color hoverColor;
    public Vector3 posOffset = new Vector3(0,0.2f,0);
    private GameObject turret;
    private Renderer rend;
    private Color startColor;
    BuildManager buildManager;
    private State otherScript;

    void Start (){
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }
   void OnMouseEnter()
   {   if(EventSystem.current.IsPointerOverGameObject())
                return;
       if(buildManager.GetTurretToBuild()==null)
       return;
       rend.material.color = hoverColor;
   }
   void OnMouseDown(){

       if(buildManager.GetTurretToBuild()==null)
       return;
       if(turret != null)
       {
           Debug.Log("Cannot build");
           return;
       } else
       {
           GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
            otherScript = GetComponent<State>();
            otherScript.value = -1.0f;
            otherScript.isBValue = true;
           turret = (GameObject)Instantiate(turretToBuild,transform.position+posOffset,transform.rotation);
       }
   }
   void OnMouseExit()
   {
       rend.material.color = startColor;
   }
}
