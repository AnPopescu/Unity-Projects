using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIfEnemy : MonoBehaviour
{
public Camera mainCamera;
public RectTransform crosshairObject;
public float maxDetectionDistance = 1000;
 
private void Update()
{
    //Send a ray from the crosshair position perpendicular to the camera
    Ray ray = mainCamera.ScreenPointToRay(crosshairObject.anchoredPosition);
 
    RaycastHit hit;
    if (Physics.Raycast(ray, out hit, maxDetectionDistance, LayerMask.GetMask("Enemy")))
    {
        //Your raycast has hit an item on layer "Item" within maxDetectionDistance
        //hit contains the data regarding the item you hit
        Debug.Log("EnemyInShigh");
    }
}
}
