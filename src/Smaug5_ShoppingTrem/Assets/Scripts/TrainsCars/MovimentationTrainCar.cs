using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentationTrainCar : MonoBehaviour
{
    public int limitPosZCharacterWalkBack;
    public int limitTrainCarInBack;

    private GameObject character;

    // Start is called before the first frame update
    void Start()
    {
        character = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GameObject[] allTrainCars = GameObject.FindGameObjectsWithTag("TrainCar");
        int trainCarsInLimitBack = 0;

        foreach (GameObject corredor in allTrainCars) {
            if (corredor.transform.position.z <= limitPosZCharacterWalkBack) {
                trainCarsInLimitBack += 1;
            }
        }

        if (character.GetComponent<MovimentationCharacter>().walkMaxForwards) {

            gameObject.transform.position = new Vector3(
                gameObject.transform.position.x,
                gameObject.transform.position.y,
                gameObject.transform.position.z - character.GetComponent<MovimentationCharacter>().
                    velOfMovimentation * Time.deltaTime);
        }
        if (character.GetComponent<MovimentationCharacter>().walkMaxBackwards && trainCarsInLimitBack 
            >= limitTrainCarInBack) {

            gameObject.transform.position = new Vector3(
                gameObject.transform.position.x,
                gameObject.transform.position.y,
                gameObject.transform.position.z + character.GetComponent<MovimentationCharacter>().
                    velOfMovimentation * Time.deltaTime);
        }
    }
}
