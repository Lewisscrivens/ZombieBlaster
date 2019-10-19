using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Text scoreCount;
    private static float score;
    private static float ehighScore;
    private static float mhighScore;
    private static float hhighScore;
    private bool scoreLoaded;
    private static float difficulty;

    // Use this for initialization
    void Start () {
        difficulty = DifficultyMenu.getDifficulty();
        score = 0;
        scoreLoaded = false;

        //Creating integers that will save the specified high score even when the game is closed
        ehighScore = PlayerPrefs.GetInt("Easy High Score");
        mhighScore = PlayerPrefs.GetInt("Medium High Score");
        hhighScore = PlayerPrefs.GetInt("Hard High Score");
    }
	
	// Update is called once per frame
	void Update () {
        //Keeps score up to date as it could change at any time
        updateScore();
    }

    //Increases the score by the number given with the method call
    public static void setScore(float increaseScore)
    {
        score += increaseScore;
    }

    //Reduces the score by the number given with the method call
    public static void reduceScore(float reduceScore)
    {
        score -= reduceScore;
    }

    //Checks the high score and if it is larger than previous high score then set to the new score
    public static void checkHighScore()
    {
        //Sets the correct highscore integer as there are three different scenarios
        if (difficulty == 0 && ehighScore < score)
        {
            ehighScore = score;
            PlayerPrefs.SetInt("Easy High Score", (int)ehighScore);
        }
        else if (difficulty == 1 && mhighScore < score)
        {
            mhighScore = score;
            PlayerPrefs.SetInt("Medium High Score", (int)mhighScore);
        }
        else if (difficulty == 2 && hhighScore < score)
        {
            hhighScore = score;
            PlayerPrefs.SetInt("Hard High Score", (int)hhighScore);
        }
    }

    //returns score values dependant on difficulty level
    public static float getEHighScore()
    {
        return ehighScore;
    }
    public static float getMHighScore()
    {
        return mhighScore;
    }
    public static float getHHighScore()
    {
        return hhighScore;
    }

    //Used to draw the score to the screen using a text box
    void updateScore()
    {
        scoreCount.text = "Score: " + score;
    }

    //Used to obtain the score in other classes
    public static float getScore()
    {
        return score;
    }
}
