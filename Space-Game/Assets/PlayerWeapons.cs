using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapons : MonoBehaviour
{
    public class Weapon //Class that each weapon is based from
    {
        public Animation shootAnim; //Shooting Animation
        public GameObject weaponGraphic; //Weapon Graphic
        public GameObject projectile;  //Weapon Bullet

        public float weaponDuration; //The duration of the powerup
        public float shootDelay; //The delay between shots
        private float shootTimer; //The time you can shoot again (used with shoot delay)
        private float shootOffSet = 1f; //The position offset of the bullet

        //Set specific model parameters
        public Weapon(float shootingDelay)
        {
            shootDelay = shootingDelay;
        }

        public void fireWeapon(GameObject defaultCam)
        {
            if (Time.time >= shootTimer)
            {
                Debug.Log("Shoot");
                //Reset the shoot timer
                shootTimer = Time.time + shootDelay;
                
                //create object (projectile) in front of player by using the camera position
                Instantiate(projectile, defaultCam.transform.position + defaultCam.transform.forward * shootOffSet, defaultCam.transform.rotation);
            }
            else
            {
                Debug.Log("Wait!");
            }
        }
    }

    public GameObject defaultBullet;
    public GameObject defaultCam;

    Weapon defaultWeapon = new Weapon(0.02f);
    Weapon currentWeapon;
    

    private void Start()
    {
        defaultWeapon.projectile = defaultBullet;
        currentWeapon = defaultWeapon;
    }

    private void Update()
    {
        if (Input.GetButton("Fire1")){
            currentWeapon.fireWeapon(defaultCam);
        }
    }
}
