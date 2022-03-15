using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManipulation : MonoBehaviour
{
    public int indiceGameOverInCanvas;
    private MovimentationCharacter playerMovimentation;

    // Start is called before the first frame update
    void Start()
    {
        playerMovimentation = GameObject.FindGameObjectWithTag("Player").GetComponent<MovimentationCharacter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMovimentation.velOfMovimentation <= 0) {
            transform.GetChild(indiceGameOverInCanvas).gameObject.SetActive(true);
        }
    }

    public void FinishGameplay() {
        SceneManager.LoadScene("MainMenu");
    }
}
