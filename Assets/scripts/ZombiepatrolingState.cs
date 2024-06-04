using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class ZombiepatrolingState : StateMachineBehaviour
{
    float timer;
    public float patrolingTime = 10f;

    Transform player;
    NavMeshAgent agent;

    public float detectionAreaRadius = 30f;
    public float patrolSpeed = 2f;

    List<Transform> waypointslist = new List<Transform>();

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = animator.GetComponent<NavMeshAgent>();

        agent.speed = patrolSpeed;
        timer = 0;

        GameObject waypointCluster = GameObject.FindGameObjectWithTag("Waypoints");
        foreach (Transform t in waypointCluster.transform)
        {
            waypointslist.Add(t);
        }

        Vector3 nextPosition = waypointslist[Random.Range(0, waypointslist.Count)].position;
        agent.SetDestination(nextPosition);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        // If agent arrived at waypoint, move to next waypoint
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            agent.SetDestination(waypointslist[Random.Range(0, waypointslist.Count)].position);
        }

        // transition to idle state
        timer += Time.deltaTime;
        if (timer > patrolingTime)
        {
            animator.SetBool("Patroling", false);
        }

        // transition to chase state
        float distanceFromPlayer = Vector3.Distance(player.position, animator.transform.position);
        if (distanceFromPlayer < detectionAreaRadius)
        {
            animator.SetBool("Chasing", true);
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //stop the agent
        agent.SetDestination(agent.transform.position);
    }

  
}
