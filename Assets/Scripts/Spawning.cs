using UnityEngine;
using System.Collections;

public class Spawning : MonoBehaviour
{
    public GameObject[] spawnPoints;
    public GameObject zombie;
    private int zombieLimit;
    private float difficulty;
    private float repeatRate;
    private float spawnTime;
    public GameObject spawner1;
    public GameObject spawner2;
    private float timeDelay;
    private float lastIncreased;

    // Use this for initialization
    void Start()
    {
        //Setting spawn tag for game objects
        spawnPoints = GameObject.FindGameObjectsWithTag("Spawn");
        difficulty = DifficultyMenu.getDifficulty();
        timeDelay = 10;

        //Checking difficulty and changing variables to make game harder if the difficulty is harder
        if (difficulty == 0)
        {
            zombieLimit = 20;
            repeatRate = 5f;
            spawnTime = 3;
            //removes two out of the four spawners
            Destroy(spawner1);
            Destroy(spawner2);
        }
        else if (difficulty == 1)
        {
            zombieLimit = 15;
            repeatRate = 3f;
            spawnTime = 3;
            //removes only one spawner
            Destroy(spawner1);
        }
        else if (difficulty == 2)
        {
            zombieLimit = 10;
            repeatRate = 2f;
            spawnTime = 2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //over time zombies will start to spawn more frequently
        if (Time.time > timeDelay + lastIncreased)
        {
            lastIncreased = Time.time;
            spawnTime -= 0.01f;
        }

        //Create game objects list of objects with the tag Zombie
        GameObject[] zombies;
        zombies = GameObject.FindGameObjectsWithTag("Zombie");

        //if enemies become bigger than the spawn limit then do not allow more to spawn
        if (zombies.Length > zombieLimit)
        {
            print("Too many zombies");
        }
        else
        {
            //(method, time between spawning in seconds, repeat rate)
            InvokeRepeating("spawnZombies", spawnTime, repeatRate);
        }
    }

    void spawnZombies()
    {
        //Position to spawn enemies, anything with the tag "Spawn"
        int SpawnPos = Random.Range(0, spawnPoints.Length);

        //Create new zombie object at randomly at one of the spawn positions
        Instantiate(zombie, spawnPoints[SpawnPos].transform.position, transform.rotation);
        CancelInvoke();
    }
}