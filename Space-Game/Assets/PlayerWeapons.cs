using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapons : MonoBehaviour
{
    public class Weapon
    {
        public Animation shootAnim;
        public GameObject projectile;

        public float weaponDuration;
        public float shootDelay;
        private float shootTimer;
        private float shootOffSet = 1f;

        public bool isDefault;

        public void fireWeapon(GameObject defaultCam)
        {
            if (Time.time >= shootTimer)
            {
                shootTimer = Time.time + shootDelay;
                
                //create object (projectile) in front of player by using the camera position
                Instantiate(projectile, defaultCam.transform.position + defaultCam.transform.forward * shootOffSet, Quaternion.identity);
            }
            else
            {
                Debug.Log("Wait!");
            }
        }
    }

    public GameObject defaultBullet;
    public GameObject defaultCam;

    Weapon defaultWeapon = new Weapon { isDefault = true, shootDelay = 0.2f};
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
