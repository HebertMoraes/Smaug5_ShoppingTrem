using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveBonusMoneyOfSales : MonoBehaviour
{
    private GameObject playerCharacter;

    // Start is called before the first frame update
    void Start()
    {
        playerCharacter = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject == playerCharacter) {
            
        }
    }
}
