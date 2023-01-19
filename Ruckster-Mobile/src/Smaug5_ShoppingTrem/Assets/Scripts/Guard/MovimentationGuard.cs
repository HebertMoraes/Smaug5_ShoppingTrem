using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentationGuard : MonoBehaviour
{
    public float delaySecToSeekPlayerChar;
    private string newMoveTo;
    private string moveTo;
    private string currentLine;
    private MovimentationCharacter playerMovimentation;
    private CharacterController charControll;
    private float posXAlreadyIncremented;
    private float posXLineLeft, posXLineMid, posXLineRight;
    private float velOfMovimentationLeftRight;

    // Start is called before the first frame update
    void Start()
    {
        currentLine = "mid";
        playerMovimentation = GameObject.FindWithTag("Player").GetComponent<MovimentationCharacter>();
        charControll = GetComponent<CharacterController>();
        posXLineLeft = playerMovimentation.posXLineLeft;
        posXLineMid = playerMovimentation.posXLineMid;
        posXLineRight = playerMovimentation.posXLineRight;
        velOfMovimentationLeftRight = playerMovimentation.velOfMovimentationLeftRight;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveTo == "right")
        {
            if (currentLine == "left")
            {
                float currentValueToIncrement = playerMovimentation.velOfMovimentationLeftRight * Time.deltaTime;
                posXAlreadyIncremented += currentValueToIncrement;
                charControll.Move(new Vector3(currentValueToIncrement, 0, 0));

                if (posXLineLeft + posXAlreadyIncremented >= posXLineMid)
                {
                    posXAlreadyIncremented = 0;
                    currentLine = "mid";
                    //alreadyMakeSecondTurn = false;
                    transform.SetPositionAndRotation(new Vector3(posXLineMid,
                        transform.position.y,
                        transform.position.z),
                        transform.rotation);
                    //isTurningLeft = false;
                    //isTurningRight = false;
                    moveTo = null;
                }
            }
            if (currentLine == "mid")
            {
                float currentValueToIncrement = velOfMovimentationLeftRight * Time.deltaTime;
                posXAlreadyIncremented += currentValueToIncrement;
                charControll.Move(new Vector3(currentValueToIncrement, 0, 0));

                if (posXLineMid + posXAlreadyIncremented >= posXLineRight)
                {
                    posXAlreadyIncremented = 0;
                    currentLine = "right";
                    //alreadyMakeSecondTurn = false;
                    transform.SetPositionAndRotation(new Vector3(posXLineRight,
                        transform.position.y,
                        transform.position.z),
                        transform.rotation);
                    //isTurningLeft = false;
                    //isTurningRight = false;
                    moveTo = null;
                }
            }
        }

        if (moveTo == "left")
        {
            if (currentLine == "mid")
            {
                float currentValueToIncrement = -playerMovimentation.velOfMovimentationLeftRight * Time.deltaTime;
                posXAlreadyIncremented += currentValueToIncrement;
                charControll.Move(new Vector3(currentValueToIncrement, 0, 0));

                if (posXLineMid + posXAlreadyIncremented <= posXLineLeft)
                {
                    posXAlreadyIncremented = 0;
                    currentLine = "left";
                    //alreadyMakeSecondTurn = false;
                    transform.SetPositionAndRotation(new Vector3(posXLineLeft,
                        transform.position.y,
                        transform.position.z),
                        transform.rotation);
                    //isTurningLeft = false;
                    //isTurningRight = false;
                    moveTo = null;
                }
            }
            if (currentLine == "right")
            {
                float currentValueToIncrement = -velOfMovimentationLeftRight * Time.deltaTime;
                posXAlreadyIncremented += currentValueToIncrement;
                charControll.Move(new Vector3(currentValueToIncrement, 0, 0));

                if (posXLineRight + posXAlreadyIncremented <= posXLineMid)
                {
                    posXAlreadyIncremented = 0;
                    currentLine = "mid";
                    //alreadyMakeSecondTurn = false;
                    transform.SetPositionAndRotation(new Vector3(posXLineMid,
                        transform.position.y,
                        transform.position.z),
                        transform.rotation);
                    //isTurningLeft = false;
                    //isTurningRight = false;
                    moveTo = null;
                }
            }
        }
    }

    public void StartTurnRight()
    {
        newMoveTo = "right";
        //mudar a currentLine aqui
        StartCoroutine("WaitForSeekPlayerCharacter");
    }

    public void StartTurnLeft()
    {
        newMoveTo = "left";
        //mudar a currentLine aqui
        StartCoroutine("WaitForSeekPlayerCharacter");
    }

    IEnumerator WaitForSeekPlayerCharacter()
    {
        yield return new WaitForSeconds(delaySecToSeekPlayerChar);
        moveTo = newMoveTo;
    }

    //
    //
    // FUNÇÃO ANTIGA DA MOVIMENTAÇÃO DO GUARDA 
    //chamado a cada frame pelo MovimentationCharacter, 
    //com valor negativo para esquerda e positivo para direita
    //
    //

    // public void TurningGuard(float velToTurnAdd)
    // {
    //     float currentValueToIncrement = velToTurnAdd * Time.deltaTime;

    //     posXAlreadyIncremented += currentValueToIncrement;

    //     if (currentLine == "left")
    //     {

    //         if (posXLineLeft + posXAlreadyIncremented >= posXLineMid)
    //         {
    //             posXAlreadyIncremented = 0;
    //             currentLine = "mid";
    //             isTurningLeft = false;
    //             isTurningRight = false;
    //             transform.SetPositionAndRotation(new Vector3(posXLineMid,
    //                 transform.position.y,
    //                 transform.position.z),
    //                 transform.rotation);
    //         }
    //         else
    //         {
    //             charControll.Move(new Vector3(currentValueToIncrement, 0, 0));
    //         }

    //     }
    //     else if (currentLine == "mid")
    //     {

    //         if (currentValueToIncrement > 0)
    //         {

    //             if (posXLineMid + posXAlreadyIncremented >= posXLineRight)
    //             {
    //                 posXAlreadyIncremented = 0;
    //                 currentLine = "right";
    //                 isTurningLeft = false;
    //                 isTurningRight = false;
    //                 transform.SetPositionAndRotation(new Vector3(posXLineRight,
    //                     transform.position.y,
    //                     transform.position.z),
    //                     transform.rotation);

    //             }
    //             else
    //             {
    //                 charControll.Move(new Vector3(currentValueToIncrement, 0, 0));
    //             }
    //         }
    //         else
    //         {

    //             if (posXLineMid + posXAlreadyIncremented <= posXLineLeft)
    //             {
    //                 posXAlreadyIncremented = 0;
    //                 currentLine = "left";
    //                 isTurningLeft = false;
    //                 isTurningRight = false;
    //                 transform.SetPositionAndRotation(new Vector3(posXLineLeft,
    //                     transform.position.y,
    //                     transform.position.z),
    //                     transform.rotation);
    //             }
    //             else
    //             {
    //                 charControll.Move(new Vector3(currentValueToIncrement, 0, 0));
    //             }
    //         }

    //     }
    //     else if (currentLine == "right")
    //     {

    //         if (posXLineRight + posXAlreadyIncremented <= posXLineMid)
    //         {
    //             posXAlreadyIncremented = 0;
    //             currentLine = "mid";
    //             isTurningLeft = false;
    //             isTurningRight = false;
    //             transform.SetPositionAndRotation(new Vector3(posXLineMid,
    //                 transform.position.y,
    //                 transform.position.z),
    //                 transform.rotation);

    //         }
    //         else
    //         {
    //             charControll.Move(new Vector3(currentValueToIncrement, 0, 0));
    //         }
    //     }
    // }
}
