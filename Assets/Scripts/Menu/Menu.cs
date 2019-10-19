using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    //Update is called once per frame
    void Update()
    {
        //When escape is pressed quit the application
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    //This method loads the scene difficulty
    public void Play()
    {
        SceneManager.LoadScene("Difficulty");
    }

    //This method loads the scene settings
    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }

    //When exit is ran the application is quit
    public void Exit()
    {
        Application.Quit();
    }
}


