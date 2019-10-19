using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DifficultyMenu : MonoBehaviour {

    public static float difficulty;

    //Update is called once per frame
    void Update()
    {
        //When escape is pressed run the goToMainMenu method
        if (Input.GetKey(KeyCode.Escape))
        {
            goToMainMenu();
        }
    }

    //When this is ran difficulty is set to 0
    public void DiffEasy()
    {
        difficulty = 0;
    }

    //When this is ran difficulty is set to 2
    public void DiffMedium()
    {
        difficulty = 1;
    }

    //When this is ran difficulty is set to 2
    public void DiffHard()
    {
        difficulty = 2;
    }

    //Loads the scene main
    public void goToMainMenu()
    {
        SceneManager.LoadScene("Main");
    }

    //loads the scene carPark
    public void loadCarpark()
    {
        SceneManager.LoadScene("CarPark");
    }

    //Ran from other classes to get the difficulty value
    public static float getDifficulty()
    {
        return difficulty;
    }
}
