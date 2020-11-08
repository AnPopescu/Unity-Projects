
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    public Camera cam;
    public LayerMask movementMask;
    public NavMeshAgent agent;
    public Interactable focus;
    PlayerMotor motor;

    // Update is called once per frame

    void Start()
    {   
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
    }
    void Update()
    {   if(EventSystem.current.IsPointerOverGameObject())
            return;
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
           if (Physics.Raycast(ray, out hit,1000, movementMask))
           {
               //MOVE AGENT
                
                motor.MoveToPoint(hit.point);

                // Stop Focusing any objects
                removeFocus();
           }

        }
        if(Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
           if (Physics.Raycast(ray, out hit,1000))
           {
               //Check if we hit interactable
               Interactable interact = hit.collider.GetComponent<Interactable>();
               // If we did /Set as focus
               if(interact != null)
               {
                   SetFocus(interact);
               }
           }

           

        }
    }
    void SetFocus(Interactable newFocus)
    {
            if(newFocus != focus)
            {   if(focus != null)
                    {
                        focus.OnDefocus();
                    }
                focus = newFocus;
                motor.FollowTarget(newFocus);
            }
       
        newFocus.OnFocused(transform);
        
    }
    void removeFocus()
    {   if(focus != null)
        {
            focus.OnDefocus();
        }
        focus = null;
        motor.StopFollowingTarget();
    }

}
