using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrainCar : MonoBehaviour
{
    public float distanceForDelete;
    public float sizeTrainCarGameObj;
    private GameObject character;
    private GameObject trainCarPrefab;
    private GameObject trainCarObjParent;

    // Start is called before the first frame update
    void Start()
    {
        character = GameObject.FindGameObjectWithTag("Player");
        //Talvez seja melhor e faça mais sentido esse prefab do corredor estar no GameController
        trainCarObjParent = GameObject.Find("AllTrainCars");
        trainCarPrefab = trainCarObjParent.GetComponent<MovTrainCarController>().trainCarPrefab;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameObject.transform.position.z <= distanceForDelete) {  

            trainCarObjParent.GetComponent<MovTrainCarController>().trainsCarsCanMove = false;   
            
            float positionZtoSpawn = trainCarObjParent.transform.GetChild(
                trainCarObjParent.transform.childCount - 1).transform.position.z + sizeTrainCarGameObj;

            //float positionZtoSpawn = trainCarObjParent.transform.GetChild(7).transform.position.z +
                //(sizeTrainCarGameObj - (sizeTrainCarGameObj / 20));

            Vector3 positionForSpawn = new Vector3(trainCarPrefab.transform.position.x, 
                trainCarPrefab.transform.position.y, 
                positionZtoSpawn);

            Instantiate(trainCarPrefab, positionForSpawn, trainCarPrefab.transform.rotation, trainCarObjParent.transform);

            trainCarObjParent.GetComponent<MovTrainCarController>().trainsCarsCanMove = true; 
            Destroy(gameObject);
        }
    }
}
