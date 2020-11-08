using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Inamic : MonoBehaviour
{
    NavMeshAgent agent;

    public Transform goal;
    private Transform player;

    public float viewRadius;
    [Range(0,360)]
    public float viewAngle;

    public LayerMask playerMask;
    public LayerMask obstacolMask;

    private bool amGasitPlayer=false;

    private Vector3 _goal;
    private Vector3 _startPoz;
    private float distanta;

    void Start()
    {
        _startPoz = transform.position;
        _goal = goal.position;
        agent = GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!amGasitPlayer)
        MoveTo();
        else if (amGasitPlayer)
        {
            AttackPlayer();
        }

        FieldOfView();
    }

    private void FieldOfView()
    {
        Collider[] targetsInView = Physics.OverlapSphere(transform.position, viewRadius, playerMask);


        for(int i=0;i<targetsInView.Length;i++)
        {
            Transform target = targetsInView[i].transform;
            Vector3 dirToTarget = (target.position - transform.position).normalized;

            if(Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2)
            {
                distanta = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, dirToTarget, distanta, obstacolMask))
                {
                    player = target;
                    AttackPlayer();
                }
            }
        }

        //distanta = player.position - transform.position;


        //float angle = Vector3.Angle(distanta, transform.forward);

        //if (angle < 5.0f)
        //{ AttackPlayer(); }
        //else
        //    amGasitPlayer = false;
    }

    private void AttackPlayer()
    {
        goal.position = player.position; amGasitPlayer = true;

        agent.destination = goal.position;

        if(Vector3.Distance(transform.position, player.position) < 1)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    void MoveTo()
    {
        if(transform.position.x != goal.position.x)
        {
            agent.destination = goal.position;
        }
        else if(transform.position.x == goal.position.x)
        {
            StartCoroutine("WaitToChangeGoalWithStart");
        }

        if(goal.position == _startPoz && transform.position.x == goal.position.x)
        {
            StartCoroutine("WaitToChangeGoalWithGoal");
        }
        //Debug.Log("Curr " + transform.position);
        //Debug.Log("Goal " + goal.position);
        //Debug.Log("Start " + _startPoz);
    }
    private IEnumerator WaitToChangeGoalWithStart()
    {
        
        yield return new WaitForSeconds(3);
        goal.position = _startPoz;
    }
    private IEnumerator WaitToChangeGoalWithGoal()
    {
        yield return new WaitForSeconds(3);
        goal.position = _goal;
    }

    public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            angleInDegrees += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
}
