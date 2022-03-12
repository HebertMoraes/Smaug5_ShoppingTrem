using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecideBuyInterest : MonoBehaviour
{
    public GameObject indicatorSalesPrefab;
    private GameObject playerCharacter;
    private float posXSpawnLeft;
    private float posXSpawnRight;
    
    // Start is called before the first frame update
    void Start()
    {
        playerCharacter = GameObject.FindGameObjectWithTag("Player");
        Inventory inventoryPLayer = playerCharacter.GetComponent<Inventory>();
        posXSpawnLeft = playerCharacter.GetComponent<MovimentationCharacter>().posXLineLeft;
        posXSpawnRight = playerCharacter.GetComponent<MovimentationCharacter>().posXLineRight;

        if (Random.value <= inventoryPLayer.chancePassengerInterestBuy) {

            //está no banco do lado direito
            if (transform.position.x > 0 ) {

                Vector3 positionToSpawn = new Vector3( 
                    posXSpawnRight, 
                    indicatorSalesPrefab.transform.position.y, 
                    transform.position.z
                );

                Instantiate(indicatorSalesPrefab, positionToSpawn, 
                    indicatorSalesPrefab.transform.rotation, transform);

            //está no banco do lado esquerdo
            } else {
                Vector3 positionToSpawn = new Vector3( 
                    posXSpawnLeft, 
                    indicatorSalesPrefab.transform.position.y, 
                    transform.position.z
                );

                Instantiate(indicatorSalesPrefab, positionToSpawn, 
                    indicatorSalesPrefab.transform.rotation, transform);
            }
        }
    }
}
