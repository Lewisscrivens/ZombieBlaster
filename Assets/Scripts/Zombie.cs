using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Zombie : MonoBehaviour {

    public GameObject zombie;
    private float hitCount;
    private float health;
    private float difficulty;
    private float zombieReward;

    // Use this for initialization
    void Start()
    {
        difficulty = DifficultyMenu.getDifficulty();
        zombieReward = 5;

        //Checking difficulty and setting zombie health to be harder if the difficulty is harder
        if (difficulty == 0)
        {
            health = 0;
        }
        else if (difficulty == 1)
        {
            health = 1;
        }
        else if (difficulty == 2)
        {
            health = 3;
        }
    }

    //Called when Zombie collides with any trigger
    void OnTriggerEnter2D(Collider2D col)
    {
        //If collided object has tag bullet then reduce health or remove zombie object
        if (col.gameObject.tag == "Bullet")
        {
            if (hitCount == health)
            {
                Destroy(gameObject);
                hitCount = 0;
                //Increase score when zombie is removed
                Score.setScore(zombieReward);

            } else
            {
                //Decreases zombies health
                hitCount = hitCount + 1;
            }
            //Destroys bullet obect on imact
            Destroy(col.gameObject);
        }
    }
}
