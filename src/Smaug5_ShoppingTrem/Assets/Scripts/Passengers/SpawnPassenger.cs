using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPassenger : MonoBehaviour
{
    public int minPassengerPerTrainCar, maxPassengerPerTrainCar;

    [Range(0, 1)]
    public float chanceToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        MovTrainCarController allTrainCars = GetComponentInParent<MovTrainCarController>();

        List<Transform> spotsPossibleSpawn = new List<Transform>();

        for (int j = 0; j <= transform.childCount - 1; j++)
        {
            spotsPossibleSpawn.Add(transform.GetChild(j));
        }

        Debug.Log(spotsPossibleSpawn.Count);

        int passengersSpawned = 0;
        for (int i = 0; i <= maxPassengerPerTrainCar - 1;)
        {
            if (Random.value <= chanceToSpawn) {

                GameObject spotChosen = spotsPossibleSpawn[Random.Range(0, spotsPossibleSpawn.Count)].gameObject;
                    spotsPossibleSpawn.Remove(spotChosen.transform);

                Instantiate(allTrainCars.passengersPrefabs[Random.Range(0, allTrainCars.passengersPrefabs.Length)], 
                    spotChosen.transform.position, 
                    spotChosen.transform.rotation,
                    transform
                );
                passengersSpawned += 1;
            
                Destroy(spotChosen);
            }
            
            if (passengersSpawned <= minPassengerPerTrainCar) 
            {
                //está abaixo do mínimo, não acrescenta para ir denovo até acertar a porcentagem 
                //e spawnar

            } else if (passengersSpawned <= maxPassengerPerTrainCar) 
            {
                i++;
            }
            
        }
    }
}
