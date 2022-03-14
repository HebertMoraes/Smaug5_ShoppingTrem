using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveBonusMoneyOfSales : MonoBehaviour
{
    public float bonusToMultiplyMoneySales;
    public float timeTotalInBonus;
    private GameObject playerCharacter;

    // Start is called before the first frame update
    void Start()
    {
        playerCharacter = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject == playerCharacter) {
            playerCharacter.GetComponent<Inventory>().BonusMoneyOfSales(bonusToMultiplyMoneySales, timeTotalInBonus);
            Destroy(gameObject);
        }
    }
}
