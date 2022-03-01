using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPlayerStateM : StateMachineBehaviour
{
    public float velocityYJump;
    private float currentVelocityYJump;
    public float valueToDecreaseVel;
    private float currentValueToDecreaseVel;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        currentVelocityYJump = velocityYJump;
        currentValueToDecreaseVel = valueToDecreaseVel;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (currentVelocityYJump > 0) {

            animator.gameObject.GetComponent<CharacterController>().Move(new Vector3(
                0, currentVelocityYJump * Time.deltaTime, 0
            ));

            currentVelocityYJump -= currentValueToDecreaseVel;
            currentValueToDecreaseVel = currentValueToDecreaseVel - (currentValueToDecreaseVel / 0.05f);
        }

        if (animator.gameObject.GetComponent<CharacterController>().isGrounded && currentVelocityYJump <= 0) {
            animator.SetInteger("stateAnim", 0);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        currentVelocityYJump = velocityYJump;
        currentValueToDecreaseVel = valueToDecreaseVel;    
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
