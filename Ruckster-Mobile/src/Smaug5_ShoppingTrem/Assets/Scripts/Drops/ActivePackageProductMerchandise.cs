using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivePackageProductMerchandise : MonoBehaviour
{
    public int valueToAddProduct;
    private GameObject playerCharacter;
    public GameObject addIndicatorProductHud;

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

            GameObject topHud = GameObject.Find("TopHud");
            GameObject newIndicator = GameObject.Instantiate(addIndicatorProductHud, topHud.transform);
            TMPro.TextMeshProUGUI txtAddValue = newIndicator.GetComponentInChildren<TMPro.TextMeshProUGUI>();
            txtAddValue.text = "+" + playerCharacter.GetComponent<Inventory>().currentProductsInInventory.ToString();

            Destroy(gameObject);
        }
    }
}
