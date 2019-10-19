using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathMenu : MonoBehaviour {

    private float finalScore;
    private float finalHighScore;
    public Text scoreText;
    public Text highScoreText;
    private float difficulty;

    // Use this for initialization
    void Start () {
        difficulty = DifficultyMenu.getDifficulty();//get difficulty from difficulty menu
        Score.checkHighScore();//update high score
        finalScore = Score.getScore();//creating local variable of score

        //Dependant on difficulty get the correct high score
        if (difficulty == 0)
        {
            finalHighScore = Score.getEHighScore();
        }
        else if (difficulty == 1)
        {
            finalHighScore = Score.getMHighScore();
        }
        else if (difficulty == 2)
        {
            finalHighScore = Score.getHHighScore();
        }
        //Set score text to the players score before death() was ran
        scoreText.text = "Score: " + finalScore.ToString();
        highScoreText.text = "High Score: " + finalHighScore.ToString();//Set high score for the current difficulty
	}

    // Update is called once per frame
    void Update()
    {
        //If escape is pressed then load the main menu scene
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("Main");
        }
        //If R is pressed then run respawnplayer
        if (Input.GetKey(KeyCode.R))
        {
            respawnPlayer();
        }
    }

    //Load the carPark scene
    public void respawnPlayer()
    {
        SceneManager.LoadScene("CarPark");
    }
}
