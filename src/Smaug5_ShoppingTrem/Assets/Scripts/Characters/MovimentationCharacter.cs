using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentationCharacter : MonoBehaviour
{   
    public float velOfMovimentation;
    public float velOfMovHorizontal;
    CharacterController charControll;
    //public static float xMove;
    public float multiplyGravityWhenFall;
    private bool walkLeft, walkRight;
    private float currentTimeOfMovimentation;
    public float timeMaxForMovimentation;

    private Animator animator;
 
    void Awake()
    {
        charControll = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update ()
    {
        //xMove = Input.GetAxis("Horizontal");
        
        /*
        //gravidade
        if (animator.GetInteger("animacaoTransicao") == 2 && !animator.GetBehaviour<JumpStateMachine>().pousando) 
        {
            gravity = 0;
        } 
        else if (animator.GetInteger("animacaoTransicao") == 2 && animator.GetBehaviour<JumpStateMachine>().pousando) 
        { 
            gravity = Physics.gravity.y * Time.deltaTime * multiplyGravityWhenFall; 
        }
        else 
        { 
            gravity = Physics.gravity.y * Time.deltaTime; 
        }
        */

        if (Input.GetKeyDown(KeyCode.LeftArrow) & !walkLeft) {

            walkLeft = true;
            walkRight = false;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) & !walkRight) {

            walkRight = true;
            walkLeft = false;
        }

        if (walkLeft) {

            if (currentTimeOfMovimentation <= timeMaxForMovimentation) {

                charControll.Move(new Vector3(-velOfMovHorizontal, Physics.gravity.y, 0) * Time.deltaTime);
                currentTimeOfMovimentation += Time.deltaTime;

            } else { walkLeft = false; walkRight = false; currentTimeOfMovimentation = 0;}
        }
        if (walkRight) {
            
            if (currentTimeOfMovimentation <= timeMaxForMovimentation) {

                charControll.Move(new Vector3(velOfMovHorizontal, Physics.gravity.y, 0) * Time.deltaTime);
                currentTimeOfMovimentation += Time.deltaTime;

            } else { walkRight = false; walkLeft = false; currentTimeOfMovimentation = 0;}
        }
    }
}
