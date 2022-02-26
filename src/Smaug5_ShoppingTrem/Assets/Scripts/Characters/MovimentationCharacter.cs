using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ESSE COMPONENTE É ULTRAPASSADO, TODA A MOVIMENTAÇAO DO PERSONAGEM VAI SER MANIPULADO PELOS STATES MACHINES
public class MovimentationCharacter : MonoBehaviour
{   
    public float velOfMovimentation;
    public float velOfMovimentationTurn;
    public float posXLine1, posXLine2, posXLine3;
    private bool isTurningLeft, isTurningRight;
    private float posXAlreadyAdded;
    private CharacterController charControll;
    private int currentLine;

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
            Turning(-velOfMovimentationTurn);
        }
        if (isTurningRight) {
            Turning(velOfMovimentationTurn);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && currentLine != 1 && (!isTurningLeft || !isTurningRight)) {
            isTurningLeft = true;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && currentLine != 3 && (!isTurningLeft || !isTurningRight)) {
            isTurningRight = true;
        }
    }

    private void Turning(float velToTurntionAdd) {

        float currentValueToAdd = velToTurntionAdd * Time.deltaTime;
        charControll.Move(new Vector3(currentValueToAdd, 0, 0));
        posXAlreadyAdded += currentValueToAdd;

        if (currentLine == 1 && transform.position.x + posXAlreadyAdded >= posXLine2) {
            posXAlreadyAdded = 0;
            currentLine = 2;
            isTurningLeft = false;
            isTurningRight = false;
            transform.SetPositionAndRotation(new Vector3(posXLine2, 
                transform.position.y, 
                transform.position.z), 
                transform.rotation);
        }

        if (currentLine == 2) {

            if (transform.position.x + posXAlreadyAdded >= posXLine3) {
                posXAlreadyAdded = 0;
                currentLine = 3;
                isTurningLeft = false;
                isTurningRight = false;
                transform.SetPositionAndRotation(new Vector3(posXLine3, 
                    transform.position.y, 
                    transform.position.z), 
                    transform.rotation);
            }
            if (transform.position.x + posXAlreadyAdded <= posXLine1) {
                posXAlreadyAdded = 0;
                currentLine = 1;
                isTurningLeft = false;
                isTurningRight = false;
                transform.position.Set(posXLine1, 0, 0);
                transform.SetPositionAndRotation(new Vector3(posXLine1, 
                    transform.position.y, 
                    transform.position.z), 
                    transform.rotation);
            }
        }

        if (currentLine == 3 && transform.position.x + posXAlreadyAdded <= posXLine2) {
            posXAlreadyAdded = 0;
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
