using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentationCharacter : MonoBehaviour
{   
    public float velOfMovimentation;
    public float velOfMovimentationLeftRight;
    public float posXLine1, posXLine2, posXLine3;
    private bool isTurningLeft, isTurningRight;
    private float posXAlreadyImcremented;
    private CharacterController charControll;
    private int currentLine;
    public GameObject trainCarPrefab;

    void Start()
    {
        currentLine = 2;
        charControll = GetComponent<CharacterController>();
    }

    void Update ()
    {
        charControll.Move(new Vector3(0, Physics.gravity.y, 0) * Time.deltaTime);

        //AQUI DEVE SER TRATADO A VELOCIDADE CRESCENTE AO DECORRER DO TEMPO NA FASE.
        //

        if (isTurningLeft) {
            Turning(-velOfMovimentationLeftRight);
        }
        if (isTurningRight) {
            Turning(velOfMovimentationLeftRight);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && currentLine != 1) {
            if (!isTurningLeft && !isTurningRight) {
                isTurningLeft = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && currentLine != 3) {
            if (!isTurningLeft && !isTurningRight) {
                isTurningRight = true;
            }
        }
    }

    private void Turning(float velToTurntionAdd) {

        float currentValueToIncrement = velToTurntionAdd * Time.deltaTime;
        charControll.Move(new Vector3(currentValueToIncrement, 0, 0));
        posXAlreadyImcremented += currentValueToIncrement;

        if (currentLine == 1 && posXLine1 + posXAlreadyImcremented >= posXLine2) {
            posXAlreadyImcremented = 0;
            currentLine = 2;
            isTurningLeft = false;
            isTurningRight = false;
            transform.SetPositionAndRotation(new Vector3(posXLine2, 
                transform.position.y, 
                transform.position.z), 
                transform.rotation);
        }

        if (currentLine == 2) {

            if (posXLine2 + posXAlreadyImcremented >= posXLine3) {
                posXAlreadyImcremented = 0;
                currentLine = 3;
                isTurningLeft = false;
                isTurningRight = false;
                transform.SetPositionAndRotation(new Vector3(posXLine3, 
                    transform.position.y, 
                    transform.position.z), 
                    transform.rotation);
            }
            if (posXLine2 + posXAlreadyImcremented <= posXLine1) {
                posXAlreadyImcremented = 0;
                currentLine = 1;
                isTurningLeft = false;
                isTurningRight = false;
                transform.SetPositionAndRotation(new Vector3(posXLine1, 
                    transform.position.y, 
                    transform.position.z), 
                    transform.rotation);
            }
        }

        if (currentLine == 3 && posXLine3 + posXAlreadyImcremented <= posXLine2) {
            posXAlreadyImcremented = 0;
            currentLine = 2;
            isTurningLeft = false;
            isTurningRight = false;
            transform.SetPositionAndRotation(new Vector3(posXLine2, 
                transform.position.y, 
                transform.position.z), 
                transform.rotation);
        }
    }
}
