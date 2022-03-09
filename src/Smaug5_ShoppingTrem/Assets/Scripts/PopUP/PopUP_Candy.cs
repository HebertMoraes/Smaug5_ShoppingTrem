using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUP_Candy : MonoBehaviour
{
    private bool isOn;
    // Start is called before the first frame update
    void Start()
    {
        isOn = false;
        transform.GetChild(0).gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (isOn)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                transform.GetChild(0).gameObject.SetActive(false);
            }
        }
    }
}
