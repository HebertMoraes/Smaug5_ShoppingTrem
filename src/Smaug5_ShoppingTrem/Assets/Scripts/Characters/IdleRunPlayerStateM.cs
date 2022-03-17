using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleRunPlayerStateM : StateMachineBehaviour
{
    private TouchScreenController touchSceenControll;

    //variavéis copiadas
    protected bool m_IsSwiping = false;
    protected Vector2 m_StartingTouch;
    private GameState gameState;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        touchSceenControll = GameObject.FindGameObjectWithTag("GameController").GetComponent<TouchScreenController>();
        gameState = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameState>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        // Use touch input on mobile
        if (Input.touchCount == 1 && 
            gameState.currentState == GameState.states.Running)
        {
			if(m_IsSwiping)
			{
				Vector2 diff = Input.GetTouch(0).position - m_StartingTouch;

				// Put difference in Screen ratio, but using only width, so the ratio is the same on both
                // axes (otherwise we would have to swipe more vertically...)
				diff = new Vector2(diff.x/Screen.width, diff.y/Screen.width);

				if(diff.magnitude > 0.01f) //we set the swip distance to trigger movement to 1% of the screen width
				{
					if(Mathf.Abs(diff.y) > Mathf.Abs(diff.x))
					{
						if(diff.y > 0)
						{
							animator.SetInteger("stateAnim", 1);
                        }
					}
						
					m_IsSwiping = false;
				}
            }

        	// Input check is AFTER the swip test, that way if TouchPhase.Ended happen a single frame after the Began Phase
			// a swipe can still be registered (otherwise, m_IsSwiping will be set to false and the test wouldn't happen for that began-Ended pair)
			if(Input.GetTouch(0).phase == TouchPhase.Began)
			{
				m_StartingTouch = Input.GetTouch(0).position;
				m_IsSwiping = true;
			}
			else if(Input.GetTouch(0).phase == TouchPhase.Ended)
			{
				m_IsSwiping = false;
			}
        }

        
        //////////////////////////////////////////////
        //////////////////////////////////////////////

        /*
        if (touchSceenControll.CheckSwipUpJump() && 
            animator.gameObject.GetComponent<MovimentationCharacter>().velOfMovimentation > 0) {

            animator.SetInteger("stateAnim", 1);
        }
        if (touchSceenControll.CheckSwipTouchToDown() && 
            animator.gameObject.GetComponent<MovimentationCharacter>().velOfMovimentation > 0) {

            animator.SetInteger("stateAnim", 2);
        }
        */
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //suponho que precise disso
        m_IsSwiping = false;
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
