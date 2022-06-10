using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPlayerStateM : StateMachineBehaviour
{
    private float currentVelocityYJump;
    private float currentValueToDecreaseVelJump;
    private CharacterController charControll;
    private bool landing;
    private float currentVelocityYLanding;
    private float currentValueToDecreaseVelLanding;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        landing = false;

        // animator.gameObject.GetComponent<CharacterSounds>().activeJumpSound();
        GameObject.Find("Sounds").GetComponent<CharacterSounds>().activeJumpSound();

        currentVelocityYJump = animator.GetFloat("velocityYJump");
        currentVelocityYLanding = animator.GetFloat("velocityYLanding");
        currentValueToDecreaseVelJump = animator.GetFloat("valueToDecreaseVelJump");
        currentValueToDecreaseVelLanding = animator.GetFloat("valueToDecreaseVelLanding");
        charControll = animator.gameObject.GetComponent<CharacterController>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!landing) {

            charControll.Move(new Vector3(
                0, 
                currentVelocityYJump * Time.deltaTime, 
                0
            ));

            currentVelocityYJump -= (currentValueToDecreaseVelJump * Time.deltaTime);
            currentValueToDecreaseVelJump -= Time.deltaTime;
            //currentValueToIncreaseVelFall = currentValueToDecreaseVel;

            if (animator.transform.position.y >= animator.GetFloat("maxHeightJump")) {
                landing = true;
                currentVelocityYJump = animator.GetFloat("velocityYJump");
                currentValueToDecreaseVelJump = animator.GetFloat("valueToDecreaseVelJump");
            }

        } else {

            if (currentVelocityYLanding < 0) {

                charControll.Move(new Vector3(
                    0, 
                    currentVelocityYLanding * Time.deltaTime, 
                    0
                ));
            }

            currentVelocityYLanding -= (currentValueToDecreaseVelLanding * Time.deltaTime);
            currentValueToDecreaseVelLanding += Time.deltaTime;
            //currentValueToIncreaseVelFall = currentValueToDecreaseVel;

            if (charControll.isGrounded) {
                currentVelocityYLanding = animator.GetFloat("velocityYLanding");
                currentValueToDecreaseVelLanding = animator.GetFloat("valueToDecreaseVelLanding");
                animator.SetInteger("stateAnim", 0);
            }
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        landing = false;
        currentVelocityYJump = animator.GetFloat("velocityYJump");
        currentVelocityYLanding = animator.GetFloat("velocityYLanding");
        currentValueToDecreaseVelJump = animator.GetFloat("valueToDecreaseVelJump");
        currentValueToDecreaseVelLanding = animator.GetFloat("valueToDecreaseVelLanding");
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
