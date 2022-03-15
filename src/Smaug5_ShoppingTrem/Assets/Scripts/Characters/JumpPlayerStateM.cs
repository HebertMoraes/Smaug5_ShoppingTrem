using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPlayerStateM : StateMachineBehaviour
{
    private float currentVelocityYJump;
    private float currentValueToDecreaseVel;
    private float currentValueToIncreaseVelFall;
    private CharacterController charControll;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        currentVelocityYJump = animator.GetFloat("velocityYJump");
        currentValueToDecreaseVel = animator.GetFloat("valueToDecreaseVelJump");
        currentValueToIncreaseVelFall = currentValueToDecreaseVel;
        charControll = animator.gameObject.GetComponent<CharacterController>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (currentVelocityYJump > 0) {

            charControll.Move(new Vector3(
                0, currentVelocityYJump * Time.deltaTime, 0
            ));

            currentVelocityYJump -= currentValueToDecreaseVel * Time.deltaTime;
            currentValueToDecreaseVel -= (((0.1f / currentValueToDecreaseVel) + 0.02f) * Time.deltaTime);
            currentValueToIncreaseVelFall = currentValueToDecreaseVel;

        } else {

            charControll.Move(new Vector3(
                0, currentVelocityYJump * Time.deltaTime, 0
            ));

            currentVelocityYJump -= currentValueToIncreaseVelFall * Time.deltaTime;
            currentValueToIncreaseVelFall -= (((0.1f * currentValueToIncreaseVelFall) + 0.02f) * Time.deltaTime);

            if (charControll.isGrounded) {
                currentVelocityYJump = animator.GetFloat("velocityYJump");
                currentValueToDecreaseVel = animator.GetFloat("valueToDecreaseVelJump"); 
                animator.SetInteger("stateAnim", 0);
            }
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        currentVelocityYJump = animator.GetFloat("velocityYJump");
        currentValueToDecreaseVel = animator.GetFloat("valueToDecreaseVelJump");
        currentValueToIncreaseVelFall = currentValueToDecreaseVel; 
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
