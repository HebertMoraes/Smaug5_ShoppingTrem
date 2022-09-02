using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowPosiition : MonoBehaviour
{
    public Transform objectToCastShadow;

    private void Start() {
    }

    void Update()
    {
        transform.SetPositionAndRotation(
            new Vector3(
                objectToCastShadow.position.x, 
                transform.position.y, 
                transform.position.z), 
                
            transform.rotation);
    }
}
