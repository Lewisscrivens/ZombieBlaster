using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    private static float health;
    private float damage;
    private static float difficulty;
    private bool isColliding;
    public Text healthText;
    public AudioSource zombiePunch;

	//Initialise Variables
	void Start () {
        //get difficulty selected from the difficulty menu class
        difficulty = DifficultyMenu.getDifficulty();
        isColliding = false;

        //Dependant on the difficulty change the health of the player to make it harder
        if (difficulty == 0)
        {
            health = 200;
        }
        else if (difficulty == 1)
        {
            health = 150;
        }
        else if (difficulty == 2)
        {
            health = 100;
        }
    }
	
	// Update is called once per frame
	void Update () {
        //When health is equal to 0 then run the death method
	    if (health == 0)
        {
            Death();
        }

        //When colliding is true and health is greater than 0, reduce health by 1
        if (isColliding == true)
        {
            if (health > 0)
            {
                health = health - 1;
            }
        }

        //Keep the healthText upto date
        healthText.text = "Health: " + health;
    }

    //Ran when player enters a trigger box
    void OnTriggerEnter2D(Collider2D col)
    {
        //If collided with object with the tag zombie then play the zombiePunch audio and reduce health
        if (col.gameObject.tag == "Zombie")
        {
            isColliding = true;
            zombiePunch.Play();
        }
    }

    //Ran when player exits a trigger box
    void OnTriggerExit2D(Collider2D col)
    {
        //If uncollided with object with tag zombie then stop reducing health
        if (col.gameObject.tag == "Zombie")
        {
            isColliding = false;
        }
    }

    //Ran when health is equal to 0, loads the death scene
    void Death()
    {
        SceneManager.LoadScene("Death");
    }

    //Set health to max for the selected difficulty
    public static void healthPack()
    {
        if (difficulty == 0)
        {
            health = 200;
        }
        else if (difficulty == 1)
        {
            health = 150;
        }
        else if (difficulty == 2)
        {
            health = 50;
        }
    }
}
