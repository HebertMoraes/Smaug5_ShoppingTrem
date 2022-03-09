using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManipulatorMenus : MonoBehaviour
{
    private float variableTest;
    private bool startAnimationToTrainGameplay;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SceneToLoadGameplay() {
        SceneManager.LoadScene("LoadingTrainGameplay");
    }

    public void OpenOptions()
    {

    }

    public void CloseOptions()
    {

    }

    public void QuitGame()
    {
        Application.Quit();
    }
    
}
