using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeVelMovimentation : MonoBehaviour
{
    public float valueChangeVelMovimentation;
    public float maxVelocityMovimentation;
    public float minVelocityMovimentation;

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<MovimentationCharacter>().velOfMovimentation > maxVelocityMovimentation) {
            GetComponent<MovimentationCharacter>().velOfMovimentation = maxVelocityMovimentation;
        }
        if (GetComponent<MovimentationCharacter>().velOfMovimentation < minVelocityMovimentation) {
            GetComponent<MovimentationCharacter>().velOfMovimentation = minVelocityMovimentation;
        }

        if (Input.GetKey(KeyCode.Z)) {

            if (GetComponent<MovimentationCharacter>().velOfMovimentation <= maxVelocityMovimentation
            && GetComponent<MovimentationCharacter>().velOfMovimentation >= minVelocityMovimentation){
                GetComponent<MovimentationCharacter>().velOfMovimentation -= valueChangeVelMovimentation * Time.deltaTime;
            }
            
        }
        if (Input.GetKey(KeyCode.X)) {

            if (GetComponent<MovimentationCharacter>().velOfMovimentation <= maxVelocityMovimentation
            && GetComponent<MovimentationCharacter>().velOfMovimentation >= minVelocityMovimentation){
                GetComponent<MovimentationCharacter>().velOfMovimentation += valueChangeVelMovimentation * Time.deltaTime;
            }
        }
    }
}
