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

            if (playerCharacter.GetComponent<MovimentationCharacter>().isTurningLeft || 
                playerCharacter.GetComponent<MovimentationCharacter>().isTurningRight) {
                
                loseSystemPlayer.AlmostHitHardOnObstacle();

            } else {
                loseSystemPlayer.HitHardOnObstacle();
            }
        }
    }
}
