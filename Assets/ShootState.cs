using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootState : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
       //shoot başlangıç durumunda, shoot durumuna geçişte bir kere çalışacak
    //   animator.GetComponent<enemyTank>().Shoot();
    //}

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //shoot durumu içerisinde sürekli yapılacak olan şey
        animator.GetComponent<enemyTank>().Shoot();

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
        //shoottan çıkarken yapılacak şey
    //}

}
