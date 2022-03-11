using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCount : MonoBehaviour
{
    private float currentScoreSteps;
    public float valueToDivideSteps;
    [HideInInspector]
    public int currentScoreSales;
    private MovimentationCharacter movCharacterBehavior;
    
    // Start is called before the first frame update
    void Start()
    {
        movCharacterBehavior = GetComponent<MovimentationCharacter>();
    }

    // Update is called once per frame
    void Update()
    {
        currentScoreSteps += (movCharacterBehavior.velOfMovimentation * Time.deltaTime) / valueToDivideSteps;

        Debug.Log("score steps: " + currentScoreSteps + " score sales: " + currentScoreSales + " money earned: " +
            GetComponent<Inventory>().moneyEarned);
    }
}
