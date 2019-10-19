using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

    public float speed;
    public Rigidbody2D rigidBody2D;
    public Vector2 movement;
    private Vector3 difference;
    public float movementX;
    public float movementY;
    private float playerRotationZ;
    public GameObject Player;
    public AudioSource purchaseSound;
    public Camera cam;
    private bool inAmmoBox;
    private bool inHealthBox;
    private float ammoPrice;
    private float healthPrice;

    //Installisation of variables
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        movement.Set(movementX,movementY);
        inAmmoBox = false;
        inHealthBox = false;
        ammoPrice = 30;
        healthPrice = 60;
    }

    // Update is called once per frame
    void Update () {

        //Move in the direction in which the key is pressed and remove velocity when the key is released
        if(Input.GetKey(KeyCode.D))
        {
            movementX = speed;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            movementX = 0;
        }
        if (Input.GetKey(KeyCode.W))
        {
            movementY = speed;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            movementY = 0;
        }
        if (Input.GetKey(KeyCode.A))
        {
            movementX = -1 * speed;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            movementX = 0;
        }
        if (Input.GetKey(KeyCode.S))
        {
            movementY = -1 * speed;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            movementY = 0;
        }

        //Ammo and health buying system
        if (Input.GetKeyUp(KeyCode.B))
        {
            float currentScore = Score.getScore();

            //If the player is inside the ammo box and the current score is more 
            //than the price of ammo then remove ammoprice from current score and run the increase ammo method from the Bullet class
            if (inAmmoBox == true && currentScore > ammoPrice)
            {
                Score.reduceScore(ammoPrice);
                Bullets.increaseAmmo();
                purchaseSound.Play();
            }
            //Otherwuse check if the player is in the health box and the current score is greater than the price of health
            //if this is true then take the price of health away from the current score and run the healthPack method from the playerhealth class
            else if (inHealthBox == true && currentScore > healthPrice)
            {
                Score.reduceScore(healthPrice);
                PlayerHealth.healthPack();
                purchaseSound.Play();
            }

        }

        //Exit playing state and load the main scene
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("Main");
        }

        //Follow Mouse
        difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        //Calculate the angle of rotation in radians and convert to degrees
        playerRotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        //rotate player by the playerRotationZ in degrees
        transform.rotation = Quaternion.Euler(0f, 0f, playerRotationZ - 90);

        //Movement Controller
        movement.Set(movementX, movementY);
        rigidBody2D.velocity = movement;
    }


    //Ran when player enteres any trigger box
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "ammoSpawn")
        {
            inAmmoBox = true;
        }
        if (col.gameObject.tag == "healthSpawn")
        {
            inHealthBox = true;
        }
    }

    //Ran when the player exits any trigger box
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "ammoSpawn")
        {
            inAmmoBox = false;
        }
        if (col.gameObject.tag == "healthSpawn")
        {
            inHealthBox = false;
        }
    }
}
