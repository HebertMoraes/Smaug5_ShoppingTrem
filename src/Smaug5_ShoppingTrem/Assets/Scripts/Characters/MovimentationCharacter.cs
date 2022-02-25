using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentationCharacter : MonoBehaviour
{
    [HideInInspector]
    public bool walkMaxForwards;
    [HideInInspector]
    public bool walkMaxBackwards;
    public float zMaxPosition;
    public float zMinPosition;
    
    public GameObject trainCarPrefab;

    public float velOfMovimentation;
    private float currentVelOfRotation;
    public float velRotationMaxForwardBackward;
    public float velRotationDefault;
    CharacterController charControll;
    public static float xMove, zMove;
    private float gravity;
    public float multiplyGravityWhenFall;

    private Animator animator;
 
    void Awake()
    {
        charControll = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update ()
    {
        CheckMaximumZ();
        MovController();
        ChangeVelRotation();
        RotationController();
    }

    // Update is called once per frame
    void MovController()
    {
        zMove = Input.GetAxis("Vertical");
        if (zMove > 0 && walkMaxForwards) {
            zMove = 0;
        }
        if (zMove < 0 && walkMaxBackwards) {
            zMove = 0;
        }

        xMove = Input.GetAxis("Horizontal");
        
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
        
        Vector3 moveAxis = new Vector3(xMove, gravity, zMove);
        charControll.Move(((moveAxis) * velOfMovimentation * Time.deltaTime));
    }
    void RotationController ()
    {
        if (xMove > 0) {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.right), 
            currentVelOfRotation * Time.deltaTime); 
        }
        else if (xMove < 0) {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.left), 
            currentVelOfRotation * Time.deltaTime); 
        }
        if (zMove > 0) {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), 
            currentVelOfRotation * Time.deltaTime);
        }
        else if (zMove < 0) {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.back), 
            currentVelOfRotation * Time.deltaTime); 
        }
    }

    void CheckMaximumZ () 
    {
        //Maximos Z
        if (transform.position.z >= zMaxPosition && Input.GetAxis("Vertical") > 0) {
            walkMaxForwards = true;
        } else { walkMaxForwards = false; }

        if (transform.position.z <= zMinPosition  && Input.GetAxis("Vertical") < 0) {
            walkMaxBackwards = true;
        } else { walkMaxBackwards = false; }
    }

    void ChangeVelRotation () 
    {
        //rotacao
        if (transform.position.z >= zMaxPosition) {
            currentVelOfRotation = velRotationMaxForwardBackward;
        } else if (transform.position.z <= zMinPosition) {
            currentVelOfRotation = velRotationMaxForwardBackward;
        } else {
            currentVelOfRotation = velRotationDefault;
        }
    }
}
