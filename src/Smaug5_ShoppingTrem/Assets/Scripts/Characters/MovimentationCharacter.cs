using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentationCharacter : MonoBehaviour
{   
    public float velOfMovimentation;
    public float velOfMovimentationLeftRight;
    public float posXLineLeft, posXLineMid, posXLineRight;
    public int valueToSlideTouchScreen;
    private bool isTurningLeft, isTurningRight;
    private float posXAlreadyIncremented;
    private CharacterController charControll;
    private string currentLine;
    private bool alreadyMakeSecondTurn;
    public GameObject trainCarPrefab;

    void Start()
    {
        currentLine = "mid";
        charControll = GetComponent<CharacterController>();
    }

    void Update ()
    {
        charControll.Move(new Vector3(0, Physics.gravity.y / 4, 0) * Time.deltaTime);

        if (isTurningLeft) {
            
            if (CheckSlideTouchToRight() && !alreadyMakeSecondTurn) {
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

            if (CheckSlideTouchToLeft() && !alreadyMakeSecondTurn) {
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

        if (CheckSlideTouchToLeft() && currentLine != "left") {
            if (!isTurningLeft && !isTurningRight) {
                isTurningLeft = true;
            }
        }
        if (CheckSlideTouchToRight() && currentLine != "right") {
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

    public bool CheckSlideTouchToLeft() {
        
        if (Input.touchCount > 0) {
            
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved) {
                if (touch.deltaPosition.x <= -valueToSlideTouchScreen) {
                    return true;
                } else { 
                    return false; 
                }
            } else { 
                return false; 
            }

        } else {
            return false;
        }
    }

    public bool CheckSlideTouchToRight() {
        
        if (Input.touchCount > 0) {
            
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved) {
                if (touch.deltaPosition.x >= valueToSlideTouchScreen) {
                    return true;
                } else { 
                    return false; 
                }
            } else { 
                return false; 
            }

        } else {
            return false;
        }
    }

    public bool CheckSlideTouchToUp() {
        
        if (Input.touchCount > 0) {
            
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved) {
                if (touch.deltaPosition.y >= valueToSlideTouchScreen) {
                    return true;
                } else { 
                    return false; 
                }
            } else { 
                return false; 
            }

        } else {
            return false;
        }
    }
}
