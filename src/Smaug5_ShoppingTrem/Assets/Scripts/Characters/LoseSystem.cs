using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseSystem : MonoBehaviour
{
    public float timeInImmortal;
    public float timeToCopPursuitNear;
    public bool alreadyHitOnce;
    public bool immortal;
    public int numberOfBlinks;
    public float valueToChangeAlphaInImmortal;
    [HideInInspector]
    public float currentTimeCopInPursuitNear;

    private Color playerCharacterColor;
    private float newAlphaToColor;
    private float secondsOnEachBlink;
    private int currentBlink;
    private bool increaseOpacity;

    private void Start() {
        playerCharacterColor = GetComponent<MeshRenderer>().material.color;
        newAlphaToColor = playerCharacterColor.a;

        secondsOnEachBlink = timeInImmortal / numberOfBlinks;
    }

    private void Update() {

        Debug.Log(newAlphaToColor);

        if (alreadyHitOnce) {

            currentTimeCopInPursuitNear += Time.deltaTime;
            
            if (immortal) {
                BlinkOpacity();
            }

            if (currentTimeCopInPursuitNear >= timeToCopPursuitNear) {
                alreadyHitOnce = false;
                currentTimeCopInPursuitNear = 0;
                increaseOpacity = false;

                GetComponent<MeshRenderer>().material.color = new Color(
                    playerCharacterColor.r, 
                    playerCharacterColor.g,
                    playerCharacterColor.b,
                    1
                );
            }
        }
    }

    public void AlmostHitHardOnObstacle() {
        
        if (!immortal) {

            GameObject.Find("Canvas").GetComponent<TxtTestHit>().RefreshTxtHit("AlmostHardHit");

            if (alreadyHitOnce) {
                HitHardOnObstacle();
            } else {
                immortal = true;
                alreadyHitOnce = true;
            }
        }
    }

    public void HitHardOnObstacle() {
        
        if (!immortal) {

            GameObject.Find("Canvas").GetComponent<TxtTestHit>().RefreshTxtHit("HardHit");
            LoseGame();
        }
    }
    public void LoseGame() {
        //preparar as pontuações e huds para o gameOver, setar velocidade do personagem para 0
        //para que os vagões param de andar 
    }

    private void BlinkOpacity() {
        
        //fazer piscar o personagem aqui
        if (increaseOpacity) {
            
            newAlphaToColor += valueToChangeAlphaInImmortal * Time.deltaTime;

            GetComponent<MeshRenderer>().material.color = new Color(
                playerCharacterColor.r, 
                playerCharacterColor.g,
                playerCharacterColor.b,
                newAlphaToColor
            );

            if (GetComponent<MeshRenderer>().material.color.a >= 1) {

                GetComponent<MeshRenderer>().material.color = new Color(
                    playerCharacterColor.r, 
                    playerCharacterColor.g,
                    playerCharacterColor.b,
                    1
                );
                increaseOpacity = false;
            }

        } else {

            newAlphaToColor -= valueToChangeAlphaInImmortal * Time.deltaTime;

            GetComponent<MeshRenderer>().material.color = new Color(
                playerCharacterColor.r, 
                playerCharacterColor.g,
                playerCharacterColor.b,
                newAlphaToColor
            );

            if (GetComponent<MeshRenderer>().material.color.a <= 0) {

                GetComponent<MeshRenderer>().material.color = new Color(
                    playerCharacterColor.r, 
                    playerCharacterColor.g,
                    playerCharacterColor.b,
                    0
                );
                increaseOpacity = true;
            }
        }


        if (currentTimeCopInPursuitNear >= timeInImmortal) {
            immortal = false;
        }
    }
}
