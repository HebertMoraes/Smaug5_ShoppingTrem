using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseSystem : MonoBehaviour
{
    //ta dando erro, não se pode dar new em um mono behavior, se usa o método AddComponent() para um GameObject, 
    //mas aqui suponho que o que deve ser feito é passar o ScoreCount já existente do Player, e para isso 
    //se usa GetComponent<ScoreCount>() no player.
    //ScoreCount steps = new ScoreCount();
    public float timeInImmortal;
    public float timeToCopPursuitNear;
    [HideInInspector]
    public bool canSave = false;
    public bool alreadyHitOnce;
    [HideInInspector]
    public bool immortal;
    public float valueToChangeAlphaInImmortal;
    public float valueToChangeAlphaInGameOver;
    [HideInInspector]
    public float currentTimeCopInPursuitNear;

    private Color playerCharacterColor;
    private float newAlphaToColor;
    private bool increaseOpacity;
    private GameState gameState;

    private void Start() {
        playerCharacterColor = GetComponent<MeshRenderer>().material.color;
        newAlphaToColor = playerCharacterColor.a;
        gameState = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameState>();
    }

    private void Update() {

        if (alreadyHitOnce && gameState.currentState == GameState.states.Running) {

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

        if (gameState.currentState == GameState.states.GameOver) {

            float newAlphaColorGameOver = GetComponent<MeshRenderer>().material.color.a - 
                (valueToChangeAlphaInGameOver * Time.deltaTime);

            GetComponent<MeshRenderer>().material.color = new Color(
                playerCharacterColor.r, 
                playerCharacterColor.g,
                playerCharacterColor.b,
                newAlphaColorGameOver
            );
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
        
        gameState.currentState = GameState.states.GameOver;

        GameObject.FindGameObjectWithTag("Player").GetComponent<MovimentationCharacter>().velOfMovimentation = 0;
        GameObject.FindGameObjectWithTag("Player").GetComponent<MovimentationCharacter>().velOfMovimentationLeftRight = 0;
        GameObject.FindGameObjectWithTag("Player").GetComponent<SaveManager>().IncrementScore();

        GameObject.Find("Canvas").GetComponent<GameOverManipulator>().PutRecordsOnUI();
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
