using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Assinatura : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F9)) {
            if (GetComponent<RawImage>().enabled) {
                GetComponent<RawImage>().enabled = false;
            } else {
                GetComponent<RawImage>().enabled = true;
            }
        }
    }
}
