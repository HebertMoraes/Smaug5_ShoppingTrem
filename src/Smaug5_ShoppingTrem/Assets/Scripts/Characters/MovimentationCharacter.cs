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
    private CharacterSounds charSounds;
    private MovimentationGuard movimentationGuard;
    private TouchScreenController touchSceenControll;

    void Start()
    {
        currentLine = "mid";
        charControll = GetComponent<CharacterController>();
        touchSceenControll = GameObject.FindGameObjectWithTag("GameController").GetComponent<TouchScreenController>();
        charSounds = GameObject.Find("Sounds").GetComponent<CharacterSounds>();
        movimentationGuard = GameObject.Find("Guard").GetComponent<MovimentationGuard>();
    }

    void Update ()
    {

        if (GetComponent<Animator>().GetInteger("stateAnim") != 1) {
            charControll.Move(new Vector3(0, Physics.gravity.y, 0) * Time.deltaTime);
        }

        if (isTurningLeft) {
            
            if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) && !alreadyMakeSecondTurn) {
                if (currentLine == "mid") {

                    isTurningLeft = false;
                    isTurningRight = true;
                    currentLine = "left";

                    float totalLeft_Mid = System.Math.Abs(posXLineMid - posXLineLeft);
                    posXAlreadyIncremented = totalLeft_Mid - System.Math.Abs(posXAlreadyIncremented);

                    alreadyMakeSecondTurn = true;
                    Turning(velOfMovimentationLeftRight);
                    movimentationGuard.TurningGuard(velOfMovimentationLeftRight);

                } else if (currentLine == "right") {

                    isTurningLeft = false;
                    isTurningRight = true;
                    currentLine = "mid";
                    
                    float totalMid_Right = posXLineRight - posXLineMid;
                    posXAlreadyIncremented = totalMid_Right - System.Math.Abs(posXAlreadyIncremented);

                    alreadyMakeSecondTurn = true;
                    Turning(velOfMovimentationLeftRight);
                    movimentationGuard.TurningGuard(velOfMovimentationLeftRight);
                }
            } else {
                Turning(-velOfMovimentationLeftRight);
                movimentationGuard.TurningGuard(-velOfMovimentationLeftRight);
            }
        }
        if (isTurningRight) {

            if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) && !alreadyMakeSecondTurn) {
                if (currentLine == "left") {

                    isTurningRight = false;
                    isTurningLeft = true;
                    currentLine = "mid";
                    
                    float totalLeft_Mid = System.Math.Abs(posXLineLeft - posXLineMid);
                    posXAlreadyIncremented = (totalLeft_Mid - posXAlreadyIncremented) * -1;

                    alreadyMakeSecondTurn = true;
                    Turning(-velOfMovimentationLeftRight);
                    movimentationGuard.TurningGuard(-velOfMovimentationLeftRight);

                } else if (currentLine == "mid") {
                    isTurningRight = false;
                    isTurningLeft = true;
                    currentLine = "right";
                    
                    float totalMid_Right = posXLineRight - posXLineMid;
                    posXAlreadyIncremented = (totalMid_Right - posXAlreadyIncremented) * -1;

                    alreadyMakeSecondTurn = true;
                    Turning(-velOfMovimentationLeftRight);
                    movimentationGuard.TurningGuard(-velOfMovimentationLeftRight);
                }
            } else {
                Turning(velOfMovimentationLeftRight);
                movimentationGuard.TurningGuard(velOfMovimentationLeftRight);
            }
        }

        if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) && currentLine != "left") {
            if (!isTurningLeft && !isTurningRight) {
                isTurningLeft = true;
            }
        }
        if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) && currentLine != "right") {
            if (!isTurningLeft && !isTurningRight) {
                isTurningRight = true;
            }
        }

        // if (isTurningLeft) {
            
        //     if (touchSceenControll.CheckSwipTouchToRight() && !alreadyMakeSecondTurn) {
        //         if (currentLine == "mid") {
        //             isTurningLeft = false;
        //             isTurningRight = true;
        //             currentLine = "left";
        //             float totalLeft_Mid = System.Math.Abs(posXLineMid - posXLineLeft);
        //             posXAlreadyIncremented = totalLeft_Mid - System.Math.Abs(posXAlreadyIncremented);
        //             alreadyMakeSecondTurn = true;
        //             Turning(velOfMovimentationLeftRight);
        //             movimentationGuard.TurningGuard(velOfMovimentationLeftRight);
        //         } else if (currentLine == "right") {
        //             isTurningLeft = false;
        //             isTurningRight = true;
        //             currentLine = "mid";
                    
        //             float totalMid_Right = posXLineRight - posXLineMid;
        //             posXAlreadyIncremented = totalMid_Right - System.Math.Abs(posXAlreadyIncremented);
        //             alreadyMakeSecondTurn = true;
        //             Turning(velOfMovimentationLeftRight);
        //             movimentationGuard.TurningGuard(velOfMovimentationLeftRight);
        //         }
        //     } else {
        //         Turning(-velOfMovimentationLeftRight);
        //         movimentationGuard.TurningGuard(-velOfMovimentationLeftRight);
        //     }
        // }
        // if (isTurningRight) {
        //     if (touchSceenControll.CheckSwipTouchToLeft() && !alreadyMakeSecondTurn) {
        //         if (currentLine == "left") {
        //             isTurningRight = false;
        //             isTurningLeft = true;
        //             currentLine = "mid";
                    
        //             float totalLeft_Mid = System.Math.Abs(posXLineLeft - posXLineMid);
        //             posXAlreadyIncremented = (totalLeft_Mid - posXAlreadyIncremented) * -1;
        //             alreadyMakeSecondTurn = true;
        //             Turning(-velOfMovimentationLeftRight);
        //             movimentationGuard.TurningGuard(-velOfMovimentationLeftRight);
        //         } else if (currentLine == "mid") {
        //             isTurningRight = false;
        //             isTurningLeft = true;
        //             currentLine = "right";
                    
        //             float totalMid_Right = posXLineRight - posXLineMid;
        //             posXAlreadyIncremented = (totalMid_Right - posXAlreadyIncremented) * -1;
        //             alreadyMakeSecondTurn = true;
        //             Turning(-velOfMovimentationLeftRight);
        //             movimentationGuard.TurningGuard(-velOfMovimentationLeftRight);
        //         }
        //     } else {
        //         Turning(velOfMovimentationLeftRight);
        //         movimentationGuard.TurningGuard(velOfMovimentationLeftRight);
        //     }
        // }
        // if (touchSceenControll.CheckSwipTouchToLeft() && currentLine != "left") {
        //     if (!isTurningLeft && !isTurningRight) {
        //         isTurningLeft = true;
        //     }
        // }
        // if (touchSceenControll.CheckSwipTouchToRight() && currentLine != "right") {
        //     if (!isTurningLeft && !isTurningRight) {
        //         isTurningRight = true;
        //     }
        // }
    }

    private void Turning(float velToTurnAdd) {

        charSounds.activeSlideHorizontalSound();

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
