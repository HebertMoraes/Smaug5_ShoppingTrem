using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeOpacityApresentation : MonoBehaviour
{
    public float timeToChangeScene;
    private float currentElapsedTime;
    private RawImage image;

    void Start()
    {
        image = gameObject.GetComponent<RawImage>();
    }

    void Update()
    {
        if (currentElapsedTime >= timeToChangeScene)
        {
            gameObject.GetComponent<ChangeScene>().ToMainMenu();

        } else if (currentElapsedTime > (timeToChangeScene / 2) + (timeToChangeScene / 4)) {

            image.color = new Color(
                image.color.r,
                image.color.g,
                image.color.b,
                image.color.a - (1.8f * Time.deltaTime));

        } else if (currentElapsedTime <= timeToChangeScene / 2) {

            image.color = new Color(
                image.color.r,
                image.color.g,
                image.color.b,
                image.color.a + (0.5f * Time.deltaTime));
        }
        currentElapsedTime += Time.deltaTime;
    }
}
