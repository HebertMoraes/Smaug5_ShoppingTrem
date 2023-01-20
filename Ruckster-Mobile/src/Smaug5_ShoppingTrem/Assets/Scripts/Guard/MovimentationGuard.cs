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
    private bool jumping;    
    private float currentVelocityYJump;
    private float currentVelocityYLanding;
    private float currentValueToDecreaseVelJump;
    private float currentValueToDecreaseVelLanding;
    private bool landing;
    private float maxHeightJump;
    private float velocityYJump;
    private float valueToDecreaseVelJump;
    private float valueToDecreaseVelLanding;

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
        if (jumping)
        {
            UpdateJump();
        } else {
            charControll.Move(new Vector3(0, Physics.gravity.y, 0) * Time.deltaTime);
        }

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
        StartCoroutine("WaitForSeekPlayerCharacter");
    }

    public void StartTurnLeft()
    {
        newMoveTo = "left";
        StartCoroutine("WaitForSeekPlayerCharacter");
    }

    public void StartJump(
            float currentVelocityYJump, 
            float currentVelocityYLanding, 
            float currentValueToDecreaseVelJump, 
            float currentValueToDecreaseVelLanding, 
            float maxHeightJump, 
            float velocityYJump, 
            float valueToDecreaseVelJump, 
            float valueToDecreaseVelLanding)
    {
        this.currentVelocityYJump = currentVelocityYJump * 1.5f;
        this.currentVelocityYLanding = currentVelocityYLanding * 1.5f;
        this.currentValueToDecreaseVelJump = currentValueToDecreaseVelJump * 1.5f;
        this.currentValueToDecreaseVelLanding = currentValueToDecreaseVelLanding * 1.5f;
        this.maxHeightJump = 3;
        this.velocityYJump = velocityYJump;
        this.valueToDecreaseVelJump = valueToDecreaseVelJump;
        this.valueToDecreaseVelLanding = valueToDecreaseVelLanding;

        StartCoroutine("WaitForStartJump");
    }

    IEnumerator WaitForSeekPlayerCharacter()
    {
        yield return new WaitForSeconds(delaySecToSeekPlayerChar);
        moveTo = newMoveTo;
    }

    IEnumerator WaitForStartJump()
    {
        jumping = false;
        yield return new WaitForSeconds(delaySecToSeekPlayerChar * 1.5f);
        jumping = true;
    }

    private void UpdateJump()
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

            if (transform.position.y >= maxHeightJump) {
                landing = true;
                currentVelocityYJump = velocityYJump;
                currentValueToDecreaseVelJump = valueToDecreaseVelJump;
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
                currentVelocityYLanding = velocityYJump;
                currentValueToDecreaseVelLanding = valueToDecreaseVelLanding;
                landing = false;
                jumping = false;
            }
        }
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
