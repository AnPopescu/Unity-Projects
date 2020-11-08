using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour
{
    // Start is called before the first frame update
    NavMeshAgent agent ;
    Transform target;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    void Update()
    { if(target !=null)
        {
            agent.SetDestination(target.position);
            FaceTarget();
        }
    }

    public void MoveToPoint(Vector3 point)
    {
        agent.SetDestination(point);
    }

    public void FollowTarget (Interactable interact)
    {
            agent.stoppingDistance = interact.radius *1.1f;
            agent.updateRotation = false;

        target = interact.transform;
    }

    public void StopFollowingTarget()
    {   agent.stoppingDistance = 0f;
                agent.updateRotation = true;

        target = null;


    }
    public void FaceTarget()
    {
            Vector3 direction = (target.position-transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x,0f,direction.z));
           transform.rotation = Quaternion.Slerp(transform.rotation,lookRotation,Time.deltaTime * 5f);
    }
    // Update is called once per frame
}

