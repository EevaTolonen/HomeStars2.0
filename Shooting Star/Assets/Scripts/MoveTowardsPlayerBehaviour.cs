using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsPlayerBehaviour : StateMachineBehaviour
{
    private GameObject boss;
    private Transform bossTr;
    private GameObject player;
    private float speed = 2;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss = GameObject.FindGameObjectWithTag("Boss");
        bossTr = animator.transform;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (bossTr != null)
        {
            float step = speed * Time.deltaTime;
            bossTr.position = Vector3.MoveTowards(bossTr.position, player.transform.position, step);
        }

    }
}
