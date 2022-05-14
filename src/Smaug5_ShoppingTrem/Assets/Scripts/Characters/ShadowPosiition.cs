using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowPosiition : MonoBehaviour
{
    private GameObject playerCharacter;

    private void Start() {

        playerCharacter = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        transform.SetPositionAndRotation(
            new Vector3(
                playerCharacter.transform.position.x, 
                transform.position.y, 
                transform.position.z), 
                
            transform.rotation);
    }
}
