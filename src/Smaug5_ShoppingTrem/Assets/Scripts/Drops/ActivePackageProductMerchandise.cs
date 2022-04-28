using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivePackageProductMerchandise : MonoBehaviour
{
    public int valueToAddProduct;
    private GameObject playerCharacter;

    // Start is called before the first frame update
    void Start()
    {
        playerCharacter = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update() {
        if (playerCharacter.GetComponent<Inventory>().currentProductsInInventory > 0) {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject == playerCharacter) {
            playerCharacter.GetComponent<Inventory>().currentProductsInInventory += valueToAddProduct;
            Destroy(gameObject);
        }
    }
}
