using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingTrainGameplayAnim : MonoBehaviour
{
    private float variableTest;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //ao invés dessa verificação por contagem, vai ser por se a animation desse mesmo gameobject
        //foi encerrada.
        if (variableTest >= 300) {
            SceneManager.LoadScene("TrainGameplay"); 
        }
        variableTest += 1;
        //Debug.Log(variableTest);
    }
}
