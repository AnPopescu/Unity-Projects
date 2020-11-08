using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
   public float radius = 46.0f ;
    bool isFocus = false;
    Transform player;
    float dist;
    float radi;
    bool hasInteracted = false;
    public bool assignedQuest;

   void OnDrawGizmosSelected()
   {
       Gizmos.color = Color.yellow;
       Gizmos.DrawWireSphere(transform.position,radius);


   }
   public virtual void Interact ()
	{  // Debug.Log("Interacting "+ transform.name);
		// This method is meant to be overwritten
		//Debug.Log("Interacting with " + transform.name);
	}
   void Update()
   
   {
       if(isFocus&&!hasInteracted)
       {
           float distance = Vector3.Distance(player.position,transform.position);
           dist = distance;
           radi = radius;
           if (distance<radius*5)
           {
               // interact
               Debug.Log("Interacting"+"with"+transform.name);
               Interact();
               hasInteracted = true;
           }
       }
   }

   public void OnFocused(Transform playerTransform)
   {
       isFocus = true;
       player = playerTransform;
       hasInteracted = false;
   }
   public void OnDefocus()
   {
       isFocus = false;
       player = null;
       hasInteracted = false;
   }

}
