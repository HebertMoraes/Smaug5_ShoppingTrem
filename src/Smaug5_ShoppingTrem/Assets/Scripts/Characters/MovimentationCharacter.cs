using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentationCharacter : MonoBehaviour
{   
    public float velOfMovimentation;
    public float velOfMovimentationLeftRight;
    public float posXLineLeft, posXLineMid, posXLineRight;
    [HideInInspector]
    public bool isTurningLeft, isTurningRight;
    private float posXAlreadyIncremented;
    private CharacterController charControll;
    private string currentLine;
    private bool alreadyMakeSecondTurn;
    private TouchScreenController touchSceenControll;

    void Start()
    {
        currentLine = "mid";
        charControll = GetComponent<CharacterController>();
        touchSceenControll = GameObject.FindGameObjectWithTag("GameController").GetComponent<TouchScreenController>();
    }

    void Update ()
    {

        //TODO: 
        //
        //movimentar para as laterais não pode ser de um oposto ao outro com o mesmo Touch, deve-se retirar
        //o dedo e refazer o movimento de slide para o local desejado novamente;
        //
        //pode-se pular quando está deslizando, finalizando a animação de slide, seu state machine e iniciando o pulo
        //direto, o mesmo vale para do pulo para slide, só que nesse caso não vai imediatemanete e sim, a gravidade 
        //é aumentada para ele pousar bem mais rápido do que o normal;
        //
        //tirar o bouncing (quicar no chão) ao pousar no chão
        //
        //

        if (GetComponent<Animator>().GetInteger("stateAnim") != 1) {
            charControll.Move(new Vector3(0, Physics.gravity.y, 0) * Time.deltaTime);
        }

        /*
        if (!isTurningLeft && !isTurningRight) {
            if (currentLine == "left") {

                transform.SetPositionAndRotation(new Vector3(posXLineLeft, 
                    transform.position.y, 
                    transform.position.z), 
                    transform.rotation);

            } else if (currentLine == "mid") {

                transform.SetPositionAndRotation(new Vector3(posXLineMid, 
                    transform.position.y, 
                    transform.position.z), 
                    transform.rotation);

            } else if (currentLine == "right") {

                transform.SetPositionAndRotation(new Vector3(posXLineRight, 
                    transform.position.y, 
                    transform.position.z), 
                    transform.rotation);
            }
        }
        */

        if (isTurningLeft) {
            
            if (touchSceenControll.CheckSwipTouchToRight() && !alreadyMakeSecondTurn) {
                if (currentLine == "mid") {

                    isTurningLeft = false;
                    isTurningRight = true;
                    currentLine = "left";

                    float totalLeft_Mid = System.Math.Abs(posXLineMid - posXLineLeft);
                    posXAlreadyIncremented = totalLeft_Mid - System.Math.Abs(posXAlreadyIncremented);

                    alreadyMakeSecondTurn = true;
                    Turning(velOfMovimentationLeftRight);

                } else if (currentLine == "right") {

                    isTurningLeft = false;
                    isTurningRight = true;
                    currentLine = "mid";
                    
                    float totalMid_Right = posXLineRight - posXLineMid;
                    posXAlreadyIncremented = totalMid_Right - System.Math.Abs(posXAlreadyIncremented);

                    alreadyMakeSecondTurn = true;
                    Turning(velOfMovimentationLeftRight);

                }
            } else {
                Turning(-velOfMovimentationLeftRight);
            }
        }
        if (isTurningRight) {

            if (touchSceenControll.CheckSwipTouchToLeft() && !alreadyMakeSecondTurn) {
                if (currentLine == "left") {

                    isTurningRight = false;
                    isTurningLeft = true;
                    currentLine = "mid";
                    
                    float totalLeft_Mid = System.Math.Abs(posXLineLeft - posXLineMid);
                    posXAlreadyIncremented = (totalLeft_Mid - posXAlreadyIncremented) * -1;

                    alreadyMakeSecondTurn = true;
                    Turning(-velOfMovimentationLeftRight);

                } else if (currentLine == "mid") {
                    isTurningRight = false;
                    isTurningLeft = true;
                    currentLine = "right";
                    
                    float totalMid_Right = posXLineRight - posXLineMid;
                    posXAlreadyIncremented = (totalMid_Right - posXAlreadyIncremented) * -1;

                    alreadyMakeSecondTurn = true;
                    Turning(-velOfMovimentationLeftRight);

                }
            } else {
                Turning(velOfMovimentationLeftRight);
            }
        }

        if (touchSceenControll.CheckSwipTouchToLeft() && currentLine != "left") {
            if (!isTurningLeft && !isTurningRight) {
                isTurningLeft = true;
            }
        }
        if (touchSceenControll.CheckSwipTouchToRight() && currentLine != "right") {
            if (!isTurningLeft && !isTurningRight) {
                isTurningRight = true;
            }
        }
    }

    private void Turning(float velToTurnAdd) {

        float currentValueToIncrement = velToTurnAdd * Time.deltaTime;

        posXAlreadyIncremented += currentValueToIncrement;
        
        if (currentLine == "left") {

            if (posXLineLeft + posXAlreadyIncremented >= posXLineMid) {
                posXAlreadyIncremented = 0;
                currentLine = "mid";
                isTurningLeft = false;
                isTurningRight = false;
                alreadyMakeSecondTurn = false;
                transform.SetPositionAndRotation(new Vector3(posXLineMid, 
                    transform.position.y, 
                    transform.position.z), 
                    transform.rotation);
            } else {
                charControll.Move(new Vector3(currentValueToIncrement, 0, 0)); 
            }

        } else if (currentLine == "mid") {

            if (currentValueToIncrement > 0) {

                if (posXLineMid + posXAlreadyIncremented >= posXLineRight) {
                    posXAlreadyIncremented = 0;
                    currentLine = "right";
                    isTurningLeft = false;
                    isTurningRight = false;
                    alreadyMakeSecondTurn = false;
                    transform.SetPositionAndRotation(new Vector3(posXLineRight, 
                        transform.position.y, 
                        transform.position.z), 
                        transform.rotation);

                } else { 
                    charControll.Move(new Vector3(currentValueToIncrement, 0, 0)); 
                }
            } else {

                if (posXLineMid + posXAlreadyIncremented <= posXLineLeft) {
                    posXAlreadyIncremented = 0;
                    currentLine = "left";
                    isTurningLeft = false;
                    isTurningRight = false;
                    alreadyMakeSecondTurn = false;
                    transform.SetPositionAndRotation(new Vector3(posXLineLeft, 
                        transform.position.y, 
                        transform.position.z), 
                        transform.rotation);
                } else { 
                    charControll.Move(new Vector3(currentValueToIncrement, 0, 0)); 
                }
            }

        } else if (currentLine == "right") {

            if (posXLineRight + posXAlreadyIncremented <= posXLineMid) {
                posXAlreadyIncremented = 0;
                currentLine = "mid";
                isTurningLeft = false;
                isTurningRight = false;
                alreadyMakeSecondTurn = false;
                transform.SetPositionAndRotation(new Vector3(posXLineMid, 
                    transform.position.y, 
                    transform.position.z), 
                    transform.rotation);

            } else { 
                charControll.Move(new Vector3(currentValueToIncrement, 0, 0)); 
            }
        } 
    }

}
