using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrainCar : MonoBehaviour
{
    public float distanceForDelete;
    public float positionZtoSpawn;
    private GameObject character;
    private GameObject trainCarPrefab;

    // Start is called before the first frame update
    void Start()
    {
        character = GameObject.FindGameObjectWithTag("Player");
        //Talvez seja melhor e faça mais sentido esse prefab do corredor estar no GameController
        trainCarPrefab = character.GetComponent<MovimentationCharacter>().trainCarPrefab;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameObject.transform.position.z <= -distanceForDelete) {
            
            Vector3 positionForSpawn = new Vector3(trainCarPrefab.transform.position.x, 
                trainCarPrefab.transform.position.y, 
                positionZtoSpawn);

            Instantiate(trainCarPrefab, positionForSpawn, trainCarPrefab.transform.rotation);
            Destroy(gameObject);
        }
    }
}
