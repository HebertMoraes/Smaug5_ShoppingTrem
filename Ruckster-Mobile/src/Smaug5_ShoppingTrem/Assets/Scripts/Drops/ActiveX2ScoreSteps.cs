using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveX2ScoreSteps : MonoBehaviour
{
    public float valueToBonus;
    public float timeTotalInBonus;
    private GameObject playerCharacter;
    
    // Start is called before the first frame update
    void Start()
    {
        playerCharacter = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject == playerCharacter) {
            playerCharacter.GetComponent<ScoreCount>().ActiveX2ScoreCount(valueToBonus, timeTotalInBonus);
            Destroy(gameObject);
        }
    }
}
