using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TxtTestHit : MonoBehaviour
{
    private TMPro.TextMeshProUGUI txtBehaviorHardHit;
    private TMPro.TextMeshProUGUI txtBehaviorAlmostHardHit;
    private TMPro.TextMeshProUGUI txtBehaviorCopTimePursuit;
    private static int numbersOfAlmostHardHit;
    private static int numbersOfhardHit;
    private LoseSystem loseSystemPlayerChar;

    // Start is called before the first frame update
    void Start()
    {
        //numbersOfhardHit = 0;
        //numbersOfAlmostHardHit = 0;

        loseSystemPlayerChar = GameObject.FindGameObjectWithTag("Player").GetComponent<LoseSystem>();

        txtBehaviorHardHit = transform.GetChild(0).gameObject.GetComponent<TMPro.TextMeshProUGUI>();
        txtBehaviorAlmostHardHit = transform.GetChild(1).gameObject.GetComponent<TMPro.TextMeshProUGUI>();
        txtBehaviorCopTimePursuit = transform.GetChild(2).gameObject.GetComponent<TMPro.TextMeshProUGUI>();
    }

    public void RefreshTxtHit(string hitMode) {

        if (hitMode == "HardHit") {
            numbersOfhardHit += 1;
            txtBehaviorHardHit.text = "Bateu em Cheio:  " + numbersOfhardHit;
        }
        if (hitMode == "AlmostHardHit") {
            numbersOfAlmostHardHit += 1;
            txtBehaviorAlmostHardHit.text = "Bateu de raspão:  " + numbersOfAlmostHardHit;
        }
        
    }

    private void Update() {

        txtBehaviorCopTimePursuit.text = "Tempo do cop seguindo perto:  " + 
            loseSystemPlayerChar.currentTimeCopInPursuitNear;
    }
}
