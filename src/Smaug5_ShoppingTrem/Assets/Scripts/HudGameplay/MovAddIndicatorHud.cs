using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovAddIndicatorHud : MonoBehaviour
{
    public float speedMov;
    public float timeSecToMov;
    private float currentTimeMov = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.currentTimeMov < this.timeSecToMov) {
            float newPosY = transform.position.y + (speedMov * Time.deltaTime);

            this.transform.SetPositionAndRotation(new Vector3(
                this.transform.position.x, 
                newPosY,
                transform.position.z
            ), 
            this.transform.rotation);

            currentTimeMov += timeSecToMov * Time.deltaTime;
        } else {
            GameObject.Destroy(this.gameObject);
        }
    }
}
