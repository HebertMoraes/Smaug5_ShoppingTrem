using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentationGuard : MonoBehaviour
{
    private GameObject playerCharacter;
    private float posXAlreadyIncremented;
    private string currentLine;
    private bool alreadyMakeSecondTurn;
    public float posXLineLeft, posXLineMid, posXLineRight;
    [HideInInspector]
    public bool isTurningLeft, isTurningRight;
    private CharacterController charControll;

    // Start is called before the first frame update
    void Start()
    {
        playerCharacter = GameObject.FindGameObjectWithTag("Player");
        charControll = GetComponent<CharacterController>();
        currentLine = "mid";
    }

    // Update is called once per frame
    void Update()
    {
        // transform.SetPositionAndRotation(new Vector3(
        //     playerCharacter.transform.position.x,
        //     transform.position.y,
        //     transform.position.z
        // ), transform.rotation);
    }

    public void TurningGuard(float velToTurnAdd)
    {
        float currentValueToIncrement = velToTurnAdd * Time.deltaTime;

        posXAlreadyIncremented += currentValueToIncrement;

        if (currentLine == "left")
        {

            if (posXLineLeft + posXAlreadyIncremented >= posXLineMid)
            {
                posXAlreadyIncremented = 0;
                currentLine = "mid";
                isTurningLeft = false;
                isTurningRight = false;
                alreadyMakeSecondTurn = false;
                transform.SetPositionAndRotation(new Vector3(posXLineMid,
                    transform.position.y,
                    transform.position.z),
                    transform.rotation);
            }
            else
            {
                charControll.Move(new Vector3(currentValueToIncrement, 0, 0));
            }

        }
        else if (currentLine == "mid")
        {

            if (currentValueToIncrement > 0)
            {

                if (posXLineMid + posXAlreadyIncremented >= posXLineRight)
                {
                    posXAlreadyIncremented = 0;
                    currentLine = "right";
                    isTurningLeft = false;
                    isTurningRight = false;
                    alreadyMakeSecondTurn = false;
                    transform.SetPositionAndRotation(new Vector3(posXLineRight,
                        transform.position.y,
                        transform.position.z),
                        transform.rotation);

                }
                else
                {
                    charControll.Move(new Vector3(currentValueToIncrement, 0, 0));
                }
            }
            else
            {

                if (posXLineMid + posXAlreadyIncremented <= posXLineLeft)
                {
                    posXAlreadyIncremented = 0;
                    currentLine = "left";
                    isTurningLeft = false;
                    isTurningRight = false;
                    alreadyMakeSecondTurn = false;
                    transform.SetPositionAndRotation(new Vector3(posXLineLeft,
                        transform.position.y,
                        transform.position.z),
                        transform.rotation);
                }
                else
                {
                    charControll.Move(new Vector3(currentValueToIncrement, 0, 0));
                }
            }

        }
        else if (currentLine == "right")
        {

            if (posXLineRight + posXAlreadyIncremented <= posXLineMid)
            {
                posXAlreadyIncremented = 0;
                currentLine = "mid";
                isTurningLeft = false;
                isTurningRight = false;
                alreadyMakeSecondTurn = false;
                transform.SetPositionAndRotation(new Vector3(posXLineMid,
                    transform.position.y,
                    transform.position.z),
                    transform.rotation);

            }
            else
            {
                charControll.Move(new Vector3(currentValueToIncrement, 0, 0));
            }
        }
    }
}
