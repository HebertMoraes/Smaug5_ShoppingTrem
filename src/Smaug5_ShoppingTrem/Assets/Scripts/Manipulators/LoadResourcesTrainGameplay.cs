using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadResourcesTrainGameplay : MonoBehaviour
{
    public GameObject trainCarPrefab;
    public GameObject characterPrefab;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("LoadRoutine");
    }

    IEnumerator LoadRoutine() {
        Debug.Log("inicio routine");
        yield return new WaitForSeconds(0.01f);
        trainCarPrefab = Resources.Load<GameObject>("TrainGameplay/TrainCar") as GameObject;
        characterPrefab = Resources.Load<GameObject>("TrainGameplay/CharacterJoao") as GameObject;
        Debug.Log("fim routine");
    }
}
