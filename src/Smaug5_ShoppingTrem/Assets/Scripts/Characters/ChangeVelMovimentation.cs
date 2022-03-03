using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeVelMovimentation : MonoBehaviour
{
    public float constantOfIncrementationVelocity;
    public float valueChangeVelMovimentation;
    public float maxVelocityMovimentation;
    public float minVelocityMovimentation;

    // Update is called once per frame
    void Update()
    {

        //Alterar velocidade da forma correta que é constante de pouco em pouco
        GetComponent<MovimentationCharacter>().velOfMovimentation += constantOfIncrementationVelocity * Time.deltaTime;
        Debug.Log("velocidade atual:  " + GetComponent<MovimentationCharacter>().velOfMovimentation);


        if (GetComponent<MovimentationCharacter>().velOfMovimentation > maxVelocityMovimentation) {
            GetComponent<MovimentationCharacter>().velOfMovimentation = maxVelocityMovimentation;
        }
        if (GetComponent<MovimentationCharacter>().velOfMovimentation < minVelocityMovimentation) {
            GetComponent<MovimentationCharacter>().velOfMovimentation = minVelocityMovimentation;
        }

        //Diminuir a velocidade de forma forçada apertando Z
        if (Input.GetKey(KeyCode.Z)) {

            if (GetComponent<MovimentationCharacter>().velOfMovimentation <= maxVelocityMovimentation
            && GetComponent<MovimentationCharacter>().velOfMovimentation >= minVelocityMovimentation){
                GetComponent<MovimentationCharacter>().velOfMovimentation -= valueChangeVelMovimentation * Time.deltaTime;
            }
            
        }
        //Aumentar a velocidade de forma forçada apertando X
        if (Input.GetKey(KeyCode.X)) {

            if (GetComponent<MovimentationCharacter>().velOfMovimentation <= maxVelocityMovimentation
            && GetComponent<MovimentationCharacter>().velOfMovimentation >= minVelocityMovimentation){
                GetComponent<MovimentationCharacter>().velOfMovimentation += valueChangeVelMovimentation * Time.deltaTime;
            }
        }
    }
}
