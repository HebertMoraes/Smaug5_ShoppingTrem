using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentationTrainCar : MonoBehaviour
{
    private GameObject character;
    private GameObject trainCarObjParent;

    // Start is called before the first frame update
    void Start()
    {
        trainCarObjParent = GameObject.Find("TrainCars");
        character = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (trainCarObjParent.GetComponent<MovTrainCarController>().trainsCarsCanMove) {

            //Aparentemente da na mesma do que a forma abaixo, mas com translate parece ser mais correto.
            gameObject.transform.Translate(new Vector3(
                0,
                0,
                -character.GetComponent<MovimentationCharacter>().velOfMovimentation * Time.deltaTime),Space.Self);

            /*
            gameObject.transform.position = new Vector3(
                gameObject.transform.position.x,
                gameObject.transform.position.y,
                gameObject.transform.position.z - character.GetComponent<MovimentationCharacter>().
                    velOfMovimentation * Time.deltaTime);
            */
        }
    }
}
