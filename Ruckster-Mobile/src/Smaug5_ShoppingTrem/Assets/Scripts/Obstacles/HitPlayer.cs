using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPlayer : MonoBehaviour
{
    private GameObject playerCharacter;
    private LoseSystem loseSystemPlayer;

    // Start is called before the first frame update
    void Start()
    {
        playerCharacter = GameObject.FindGameObjectWithTag("Player");
        loseSystemPlayer = playerCharacter.GetComponent<LoseSystem>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject == playerCharacter) {

            if (GameObject.FindGameObjectWithTag("Player").GetComponent<MovimentationCharacter>().velOfMovimentation > 0) {

                //se está movendo, mas antes, estava sendo verificado se o isTurnLeft ou isTurnRight estavam true
                if (playerCharacter.GetComponent<CharacterController>().velocity.x != 0) {
                
                    loseSystemPlayer.AlmostHitHardOnObstacle();

                } else {

                    loseSystemPlayer.HitHardOnObstacle();
                }
            }
        }
    }
}
