using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseSystem : MonoBehaviour
{
    public float timeToCopPursuitNear;
    public bool alreadyHitOnce;
    [HideInInspector]
    public float currentTimeCopInPursuitNear;

    private void Update() {

        if (alreadyHitOnce) {

            currentTimeCopInPursuitNear += Time.deltaTime;
            
            if (currentTimeCopInPursuitNear >= timeToCopPursuitNear) {
                currentTimeCopInPursuitNear = 0;
                alreadyHitOnce = false;
            }
        }
    }

    public void AlmostHitHardOnObstacle() {
        
        GameObject.Find("Canvas").GetComponent<TxtTestHit>().RefreshTxtHit("AlmostHardHit");

        if (alreadyHitOnce) {
            HitHardOnObstacle();
        } else {
            alreadyHitOnce = true;
        }

    }

    public void HitHardOnObstacle() {
        
        GameObject.Find("Canvas").GetComponent<TxtTestHit>().RefreshTxtHit("HardHit");

        LoseGame();
    }
    public void LoseGame() {
        
    }
}
