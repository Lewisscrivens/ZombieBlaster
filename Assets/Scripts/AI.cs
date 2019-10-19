using UnityEngine;
using System.Collections;

public class AI : MonoBehaviour {

    private Vector3 playerLocation;
    private Vector2 playerDirection;
    private Vector3 difference;
    private float xVal;
    private float yVal;
    private float speed;
    public Rigidbody2D zombie;
    private float difficulty;

	// Use this for initialization
	void Start () {
	    difficulty = DifficultyMenu.getDifficulty();

        //Dependant on the difficulty instalise the speed variable
        if (difficulty == 0)
        {
            speed = (float)1.0;
        }
        else if (difficulty == 1)
        {
            speed = (float)1.2;
        }
        else if (difficulty == 2)
        {
            speed = (float)1.5;
        }
    }
	
	// Update is called once per frame
	void Update () {

        //Movement of objects using the script
        playerLocation = GameObject.FindGameObjectWithTag("Player").transform.position;//get player location
        xVal = playerLocation.x - transform.position.x;
        yVal = playerLocation.y - transform.position.y;
        playerDirection = new Vector2(xVal, yVal);//Create straight velocity path towards player location
        zombie.AddForce(playerDirection.normalized * speed);//Add force allong the player direction path at a set speed

        //Rotation of zombie towards player
        difference = playerLocation - transform.position;
        difference.Normalize();
        float zombieRotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;//trig function used to work out the zombies rotation to face the player in degrees
        transform.rotation = Quaternion.Euler(0f, 0f, zombieRotationZ - 90);//Rotates zombie to face player using zombieRotationZ in degrees
    }
}
