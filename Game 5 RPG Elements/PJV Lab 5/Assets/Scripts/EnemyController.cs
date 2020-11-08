using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyController : MonoBehaviour
{   

    public float lookRadius = 90f;
    Transform target;
    NavMeshAgent agent;
    CharacterCombat combat;
    public Transform goal;

    private Vector3 _goal;
    private Vector3 _startPoz;

    Animator skeleton ;
    float distantaoprire;
    

    float dist;

    // Start is called before the first frame update
    void Start()
    {   _startPoz = transform.position;
        _goal = goal.position;
        skeleton = GetComponentInChildren<Animator>();
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        combat = GetComponent<CharacterCombat>();
    }
    void OnDrawGizmoSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position,lookRadius);
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position , transform.position);
        dist = distance;
        
        if(distance>lookRadius)
        {   skeleton.SetBool("Walk",true);
            MoveTo();

        }
        
        if(distance<=lookRadius)
        {
            agent.SetDestination(target.position);
           // Debug.Log("SeteazaDest");
            distantaoprire = agent.stoppingDistance;
            skeleton.SetBool("Run",true);
            skeleton.SetBool("Enemy",false);
                if(distance<= 50f)
                {   
                    //attack ttarget
                    CaracterStats targetStats = target.GetComponent<CaracterStats>();
                    if(targetStats!=null)
                    {       skeleton.SetBool("Run",false);
                        skeleton.SetBool("Walk",false);
                            skeleton.SetBool("Enemy",true);
                            combat.Attack(targetStats);
                    }
                    
                    // face target
                    faceTarget();
                    Debug.Log("IntoarceSprePlayer");
                } 
        }
    }

    void faceTarget()
    {   Vector3 direction = (target.position- transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x,0,direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation,Time.deltaTime*5f);

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

    void MoveTo()
    {
        if(transform.position.x != goal.position.x)
        {   skeleton.SetBool("Walk",true);
            agent.destination = goal.position;
        }
        else if(transform.position.x == goal.position.x)
        {   
            skeleton.SetBool("Walk",false);
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

    
}
