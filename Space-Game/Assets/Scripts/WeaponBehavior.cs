using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBehavior : MonoBehaviour
{
    private float shootTimer;
    public float shootDelay;

    public float shootOffSetX;
    public float shootOffSetY;
    public float shootOffSetZ;

    public GameObject bullet;
    public GameObject mainCam;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            FireWeapon();
        }
    }

    public void FireWeapon()
    {
        if (Time.time >= shootTimer)
        {
            Debug.Log("Shoot");
            //Reset the shoot timer
            shootTimer = Time.time + shootDelay;

            //create object (projectile) in front of player by using the camera position
            Vector3 bulletOffset = new Vector3(0, shootOffSetY, shootOffSetZ);
            Instantiate(bullet, transform.position + bulletOffset, mainCam.transform.rotation);
        }
        else
        {
            Debug.Log("Wait!");
        }
    }
}
