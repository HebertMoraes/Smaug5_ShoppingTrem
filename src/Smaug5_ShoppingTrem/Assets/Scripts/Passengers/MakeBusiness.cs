using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeBusiness : MonoBehaviour
{
    private GameObject playerCharacter;
    private Inventory inventoryPlayer;

    // Start is called before the first frame update
    void Start()
    {
        playerCharacter = GameObject.FindGameObjectWithTag("Player");
        inventoryPlayer = playerCharacter.GetComponent<Inventory>();
    }

    private void Update() {
        if (inventoryPlayer.currentProductsInInventory <= 0) {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other) {

        if (other.gameObject == playerCharacter) {

            if (playerCharacter.GetComponent<Inventory>().currentProductsInInventory > 0) {

                playerCharacter.GetComponent<Inventory>().MakeBusinessWithPassenger();
                Destroy(gameObject);
            }
            
        }
    }
}
