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
        private float shootOffSetZ = 0.5f; //The position offset of the bullet
        private float shootOffSetY = 0.2f;

        //Sets weapon parameters/models
        public Weapon(float shootingDelay, GameObject gunGraphic, GameObject gunBullet)
        {
            shootDelay = shootingDelay;
            projectile = gunBullet;
            Camera camera = Camera.main;

            //Spawn in the weapon and rotate the model accordingly
            Vector3 spawnLocation = new Vector3(camera.transform.position.x + 0.5f, camera.transform.position.y - 0.5f, camera.transform.position.z + 0.8f);
            weaponGraphic = Instantiate(gunGraphic, spawnLocation, camera.transform.rotation, camera.transform);
            weaponGraphic.transform.localRotation = Quaternion.Euler(0, -90 , 0);
        }

        public void fireWeapon(GameObject defaultCam)
        {
            if (Time.time >= shootTimer)
            {
                Debug.Log("Shoot");
                //Reset the shoot timer
                shootTimer = Time.time + shootDelay;

                //create object (projectile) in front of player by using the camera position
                Vector3 bulletOffset = new Vector3(0, shootOffSetY, shootOffSetZ);
                Instantiate(projectile, weaponGraphic.transform.position + bulletOffset, defaultCam.transform.rotation);
            }
            else
            {
                Debug.Log("Wait!");
            }
        }

        public void deleteWeapon()
        {
            Destroy(this.weaponGraphic);
        }
    }

    public GameObject defaultBullet;
    public GameObject defaultCam;
    public GameObject defaultGunGraphic;

    public Weapon defaultWeapon;
    public Weapon currentWeapon;
    

    private void Start()
    {
        defaultWeapon = new Weapon(0.02f, defaultGunGraphic, defaultBullet);
        currentWeapon = defaultWeapon;
    }

    private void Update()
    {
        if (Input.GetButton("Fire1")){
            currentWeapon.fireWeapon(defaultCam);
        }
    }
}
