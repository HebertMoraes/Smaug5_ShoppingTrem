using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentationTrainCar : MonoBehaviour
{
    private GameObject character;

    // Start is called before the first frame update
    void Start()
    {
        character = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        gameObject.transform.position = new Vector3(
            gameObject.transform.position.x,
            gameObject.transform.position.y,
            gameObject.transform.position.z - character.GetComponent<MovimentationCharacter>().
                velOfMovimentation * Time.deltaTime);
    }
}
