using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseSystem : MonoBehaviour
{
    public float timeInImmortal;
    public float timeToCopPursuitNear;
    [HideInInspector]
    public bool alreadyHitOnce;
    [HideInInspector]
    public bool immortal;
    public float valueToChangeAlphaInImmortal;
    [HideInInspector]
    public float currentTimeCopInPursuitNear;

    private Color playerCharacterColor;
    private float newAlphaToColor;
    private bool increaseOpacity;

    private void Start() {
        playerCharacterColor = GetComponent<MeshRenderer>().material.color;
        newAlphaToColor = playerCharacterColor.a;
        
    }

    private void Update() {

        if (alreadyHitOnce) {

            currentTimeCopInPursuitNear += Time.deltaTime;
            
            if (immortal) {
                if (increaseOpacity) {
                    BlinkOpacity(valueToChangeAlphaInImmortal);
                }
                else {
                    BlinkOpacity(-valueToChangeAlphaInImmortal);
                }
            }

            if (currentTimeCopInPursuitNear >= timeToCopPursuitNear) {
                alreadyHitOnce = false;
                currentTimeCopInPursuitNear = 0;
                increaseOpacity = false;
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

    private void BlinkOpacity(float valueToChangeAlpha) {
        
        //fazer piscar o personagem aqui
        newAlphaToColor += valueToChangeAlpha * Time.deltaTime;

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
            newAlphaToColor = 1;
        }
        if (GetComponent<MeshRenderer>().material.color.a <= 0) {

            GetComponent<MeshRenderer>().material.color = new Color(
                playerCharacterColor.r, 
                playerCharacterColor.g,
                playerCharacterColor.b,
                0
            );
            increaseOpacity = true;
            newAlphaToColor = 0;
        }

        if (currentTimeCopInPursuitNear >= timeInImmortal) {
            
            immortal = false;

            GetComponent<MeshRenderer>().material.color = new Color(
                playerCharacterColor.r, 
                playerCharacterColor.g,
                playerCharacterColor.b,
                1
            );
        }
    }
}
