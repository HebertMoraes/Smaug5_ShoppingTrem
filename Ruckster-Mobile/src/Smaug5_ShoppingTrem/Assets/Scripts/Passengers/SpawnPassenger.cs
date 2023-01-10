using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPassenger : MonoBehaviour
{
    public int minPassengerPerTrainCar, maxPassengerPerTrainCar;
    public int indicePassengerSpots;
    [Range(0, 1)]
    public float chanceToSpawn;
    public List<GameObject> passengersPrefabs;

    private List<Transform> spotsPossibleSpawn;
    private int passengersSpawned;

    // Start is called before the first frame update
    void Start()
    {
        spotsPossibleSpawn = new List<Transform>();

        for (int j = 0; j <= transform.GetChild(indicePassengerSpots).childCount - 1; j++)
        {
            spotsPossibleSpawn.Add(transform.GetChild(indicePassengerSpots).GetChild(j));
        }

        for (int i = 0; i < maxPassengerPerTrainCar;)
        {
            if (passengersSpawned < minPassengerPerTrainCar) 
            {
                SpawnPassengerMethod();
                i++;

            } else if (passengersSpawned < maxPassengerPerTrainCar) 
            {
                if (Random.value <= chanceToSpawn) {
                
                    SpawnPassengerMethod();
                }
                i++;
            } else {
                i++;
            }
        }
    }

    private void SpawnPassengerMethod() {

        int indiceChosen = Random.Range(0, spotsPossibleSpawn.Count);
        Transform spotChosen = spotsPossibleSpawn[indiceChosen];
        spotsPossibleSpawn.RemoveAt(indiceChosen);

        Instantiate(passengersPrefabs[Random.Range(0, passengersPrefabs.Count)], 
            spotChosen.position, 
            spotChosen.rotation,
            transform.GetChild(indicePassengerSpots)
        );
        passengersSpawned += 1;
            
        Destroy(spotChosen.gameObject);
    }
}
