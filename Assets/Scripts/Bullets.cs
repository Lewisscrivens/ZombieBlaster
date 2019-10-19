using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Bullets : MonoBehaviour {

    public Rigidbody2D bulletPrefab;
    private static float ammoTotal;
    private static float ammo;
    private static float ammoSize;
    private double coolDownDelay;
    private float coolDown = 0;
    private float bulletSpeed = 500;
    private Vector3 bulletPosition;
    private Vector3 mousePosition;
    private Vector3 difference;
    private Vector2 bulletVelocity;
    private Rigidbody2D bPrefab;
    public AudioSource reloadSound;
    public AudioSource pistolSound;
    public AudioSource shotgunSound;
    public AudioSource machineGunSound;
    private bool noAmmo = false;
    public Text ammoDisplay;
    public Text reloadText;
    private float bulletRotationZ;
    private float bulletTrajecotry;
    private double xVal;
    private double yVal;
    private static string selectedWeapon;
    private static bool ammoSet = false;

    //Initialisation of Variables
    void Start ()
    {
        mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.0f);
        reloadText.enabled = false;
        ammo = 10;
        ammoSize = 10;
        ammoTotal = 100;
        ammoSet = true;
        coolDownDelay = 0.5;
    }
	
	//Update is called once per frame
	void Update ()
    {
        //If current time is greater than cooldown run contents
        if (Time.time > coolDown)
        {
            //If ammo is equal to 0 then set noAmmo to true and enable the reload text in the center of the screen
            if (ammo == 0)
            {
                noAmmo = true;
                reloadText.enabled = true;
            }
            //If mouse button is pressed and there is ammo then run the firepistol method and reduce available ammo
            if (Input.GetMouseButton(0) && noAmmo == false)
            {
                firePistol();
                ammo = ammo - 1;
            }
        }

        //If R is pressed and there is ammo available then play the reload size and reduce ammoTotal by ammoSize and set ammo back to normal
        if (Input.GetKey(KeyCode.R) && ammoTotal != 0 && noAmmo == true)
        {
            reloadSound.Play();
            ammo = ammoSize;
            ammoTotal = ammoTotal - ammo;
            noAmmo = false;
            reloadText.enabled = false;
        }

        //Keep ammo text up to date on UI
        ammoDisplay.text = "Ammo: " + ammo + " " + "/" + ammoTotal;
    }

    //This method gets the rotations for both the bullet and bullet Trajectory
    public void getRotations()
    {
        difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        bulletRotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;//Working out rotation from mouse position
        bulletTrajecotry = Mathf.Atan2(difference.y, difference.x);//Finding angle of bullet trajectory in radians

        bulletPosition = Quaternion.AngleAxis(bulletTrajecotry, transform.up) * transform.up;//When the bullet spawns it will spawn at the end of the gun on the sprite
        transform.rotation = Quaternion.Euler(0f, 0f, bulletRotationZ - 90);//Rotates new Bullet Object to match player rotation

        //Setting rotation of bullet trajectory
        xVal = System.Math.Cos(bulletTrajecotry);
        yVal = System.Math.Sin(bulletTrajecotry);
        bulletVelocity.Set((float)xVal, (float)yVal);
    }

    //This method runs the pistol sound and fireBullet method.
    public void firePistol()
    {
        pistolSound.Play();
        fireBullet();
    }

    public void fireBullet()
    {
        getRotations();//Runs the getRotation method to find the direction the player is facing and the rotation of the bullet and bulletpath
        bPrefab = Instantiate(bulletPrefab, transform.position + bulletPosition, transform.rotation) as Rigidbody2D;//Creating new bullet object relative to the players rotation

        bPrefab.GetComponent<Rigidbody2D>().AddForce(bulletVelocity * bulletSpeed);//Setting veleocity path for new bullet object

        //Destroy bullet after 2 seconds
        Destroy(bPrefab.gameObject, 2);

        //Dont run again until cooldown timer is done
        coolDown = Time.time + (float)coolDownDelay;
    }

    //Set the ammo variables back to normal (give player max ammo)
    public static void increaseAmmo()
    {
        ammo = 10;
        ammoSize = 10;
        ammoTotal = 100;
    }
}
