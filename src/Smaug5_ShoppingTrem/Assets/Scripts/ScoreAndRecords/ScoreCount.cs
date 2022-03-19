using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCount : MonoBehaviour
{
    [HideInInspector]
    public SaveManager save;
    public float currentScoreSteps;
    public float valueToDivideSteps;
    [HideInInspector]
    public int currentScoreSales;
    private MovimentationCharacter movCharacterBehavior;
    [HideInInspector]
    private float x2BonusScoreCount;
    private float currentTimeX2BonusScoreCount;
    private float timeTotalX2BonusScoreCount;
    
    // Start is called before the first frame update
    void Start()
    {
        movCharacterBehavior = GetComponent<MovimentationCharacter>();
        x2BonusScoreCount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (x2BonusScoreCount != 1) {
            currentTimeX2BonusScoreCount += Time.deltaTime;
            if (currentTimeX2BonusScoreCount >= timeTotalX2BonusScoreCount) {
                x2BonusScoreCount = 1;
                currentTimeX2BonusScoreCount = 0;
            }
        }

        currentScoreSteps += ((movCharacterBehavior.velOfMovimentation * Time.deltaTime) / valueToDivideSteps) 
            * x2BonusScoreCount;

        //Debug.Log("score steps: " + currentScoreSteps + " score sales: " + currentScoreSales + " money earned: " +
            // GetComponent<Inventory>().moneyEarned);
    }

    public void ActiveX2ScoreCount(float valueToBonus, float timeInBonus) {
        currentTimeX2BonusScoreCount = 0;
        x2BonusScoreCount = valueToBonus;
        timeTotalX2BonusScoreCount = timeInBonus;
    }
}
