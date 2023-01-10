using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    public int minObstaclesrPerTrainCar, maxObstaclesPerTrainCar;
    [Range(0, 1)]
    public float chanceToSpawn;
    [Range(0, 1)]
    public float chanceToSpawnAfterOneSpawned;
    public int indiceObstaclesSpots;
    public List<GameObject> obstaclesPrefabs;

    private List<Transform> spotsPossibleSpawn;
    private int obstaclesSpawned;
    private bool obstacleSpawnedLastSpot;
    private float posXLineLeft, posXLineMid, posXLineRight;

    // Start is called before the first frame update
    void Start()
    {
        spotsPossibleSpawn = new List<Transform>();

        MovimentationCharacter playerMovBehavior = GameObject.FindGameObjectWithTag("Player").
            GetComponent<MovimentationCharacter>();
        posXLineLeft = playerMovBehavior.posXLineLeft;
        posXLineMid = playerMovBehavior.posXLineMid;
        posXLineRight = playerMovBehavior.posXLineRight;

        for (int j = 0; j <= transform.GetChild(indiceObstaclesSpots).childCount - 1; j++)
        {
            spotsPossibleSpawn.Add(transform.GetChild(indiceObstaclesSpots).GetChild(j));
        }
        
        for (int i = 0; i < maxObstaclesPerTrainCar;)
        {
            if (obstaclesSpawned < minObstaclesrPerTrainCar) 
            {
                SpawnObstaclesMethod();
                i++;
            } else if (obstaclesSpawned < maxObstaclesPerTrainCar) 
            {
                if (obstacleSpawnedLastSpot) {
                    if (Random.value <= chanceToSpawnAfterOneSpawned) {
                        SpawnObstaclesMethod();
                    } else {
                        obstacleSpawnedLastSpot = false;
                    }
                } else {
                    
                    if (Random.value <= chanceToSpawn) {
                        SpawnObstaclesMethod();
                    } else {
                        obstacleSpawnedLastSpot = false;
                    }
                }
                i++;

            } else {
                i++;
            }
        }
    }
    private void SpawnObstaclesMethod() {
        
        int indiceChosen = Random.Range(0, spotsPossibleSpawn.Count);
        Transform spotChosen = spotsPossibleSpawn[indiceChosen];
        spotsPossibleSpawn.RemoveAt(indiceChosen);
        
        List<float> possiblesPosXLines = new List<float>();
        possiblesPosXLines.Add(posXLineLeft);
        possiblesPosXLines.Add(posXLineMid);
        possiblesPosXLines.Add(posXLineRight);
        float posXChosen = possiblesPosXLines[Random.Range(0, 3)];

        Vector3 positionXObstacleChosenToSpawn = new Vector3(
            posXChosen,
            spotChosen.transform.position.y,
            spotChosen.transform.position.z
        );

        Instantiate(obstaclesPrefabs[Random.Range(0, obstaclesPrefabs.Count)], 
            positionXObstacleChosenToSpawn, 
            spotChosen.rotation,
            transform.GetChild(indiceObstaclesSpots)
        );
        obstaclesSpawned += 1;
            
        Destroy(spotChosen.gameObject);

        obstacleSpawnedLastSpot = true;
    }
}
