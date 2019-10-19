using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour {

    //Set all highscore integers that are saved when the game is closed to 0
    public void resetHighScores()
    {
        PlayerPrefs.SetInt("Easy High Score", 0);
        PlayerPrefs.SetInt("Medium High Score", 0);
        PlayerPrefs.SetInt("Hard High Score", 0);
    }

    //load the main scene when back is ran
    public void Back()
    {
        SceneManager.LoadScene("Main");
    }
}
