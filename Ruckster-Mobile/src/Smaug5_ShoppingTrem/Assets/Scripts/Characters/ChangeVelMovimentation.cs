using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeVelMovimentation : MonoBehaviour
{
    public float constantOfIncrementationVelocity;
    public float maxVelocityMovimentation;

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<MovimentationCharacter>().velOfMovimentation > 0) {
            GetComponent<MovimentationCharacter>().velOfMovimentation += constantOfIncrementationVelocity * Time.deltaTime;
        }

        if (GetComponent<MovimentationCharacter>().velOfMovimentation > maxVelocityMovimentation) {
            GetComponent<MovimentationCharacter>().velOfMovimentation = maxVelocityMovimentation;
        }
    }
}
