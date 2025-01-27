using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class ZPatrolState : StateMachineBehaviour
{
    List<Transform> wayPoints = new List<Transform>();
    NavMeshAgent agentZom;

    float timer;
    Transform player;
    float chaseRange = 8;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agentZom = animator.GetComponent<NavMeshAgent>();
        agentZom.speed = 1.5f;
        timer = 0;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        GameObject gO = GameObject.FindGameObjectWithTag("WayZPoints");
        foreach (Transform t in gO.transform)
        {
            wayPoints.Add(t);
        }

        agentZom.SetDestination(wayPoints[Random.Range(0, wayPoints.Count)].position);
        
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       if (agentZom.remainingDistance <= agentZom.stoppingDistance)
        {
            agentZom.SetDestination(wayPoints[Random.Range(0, wayPoints.Count)].position);
        }
        
        timer += Time.deltaTime;
        if (timer > 5)
        {
            animator.SetBool("isPatrolling", false);
        }
        float distance = Vector3.Distance(player.position, animator.transform.position);
        if (distance < chaseRange)
        {
            animator.SetBool("isChasing", true);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agentZom.SetDestination(agentZom.transform.position);
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
