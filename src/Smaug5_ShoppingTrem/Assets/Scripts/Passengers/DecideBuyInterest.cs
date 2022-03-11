using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecideBuyInterest : MonoBehaviour
{
    public GameObject indicatorSalesPrefab;
    public float adjustmentPosX;
    
    // Start is called before the first frame update
    void Start()
    {
        Inventory inventoryPLayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();

        if (Random.value <= inventoryPLayer.chancePassengerInterestBuy) {

            //está no banco do lado direito
            if (transform.position.x > 0 ) {

                Vector3 positionToSpawn = new Vector3( 
                    transform.position.x + (-adjustmentPosX), 
                    indicatorSalesPrefab.transform.position.y, 
                    transform.position.z
                );

                Instantiate(indicatorSalesPrefab, positionToSpawn, 
                    indicatorSalesPrefab.transform.rotation, transform);

            //está no banco do lado esquerdo
            } else {
                Vector3 positionToSpawn = new Vector3( 
                    transform.position.x + adjustmentPosX, 
                    indicatorSalesPrefab.transform.position.y, 
                    transform.position.z
                );

                Instantiate(indicatorSalesPrefab, positionToSpawn, 
                    indicatorSalesPrefab.transform.rotation, transform);
            }
        }
    }
}
