using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeBusiness : MonoBehaviour
{
    private GameObject playerCharacter;
    private Inventory playerInventoryBehavior;

    // Start is called before the first frame update
    void Start()
    {
        playerCharacter = GameObject.FindGameObjectWithTag("Player");
        playerInventoryBehavior = playerCharacter.GetComponent<Inventory>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject == playerCharacter) {
            playerInventoryBehavior.MakeBusinessWithPassenger();
        }
    }
}
