using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBehavior : MonoBehaviour
{
    private float shootTimer;
    private float currentShootDelay;
    public float defaultShootDelay;

    public float shootOffSetX;
    public float shootOffSetY;
    public float shootOffSetZ;

    public GameObject defaultBullet;
    public GameObject mainCam;
    private GameObject currentBullet;

    Animator animator;

    private void Start()
    {
        //Set the current settings to the default
        currentBullet = defaultBullet;
        currentShootDelay = defaultShootDelay;
        //Set animator component
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            FireWeapon();
            animator.SetTrigger("isShooting");
        }
        else
        {
            animator.ResetTrigger("isShooting");
        }
    }

    private void FireWeapon()
    {
        if (Time.time >= shootTimer)
        {
            Debug.Log("Shoot");
            //Reset the shoot timer
            shootTimer = Time.time + currentShootDelay;

            //create object (projectile) in front of player by using the camera position for every gun on player
            for(int i = 0; i < transform.childCount; i++)
            {
                Transform gun = transform.GetChild(i);
                Vector3 bulletOffset = new Vector3(shootOffSetX, shootOffSetY, shootOffSetZ);
                Instantiate(currentBullet, gun.position + bulletOffset, mainCam.transform.rotation);
            }
            
        }
        else
        {
            Debug.Log("Wait!");
        }
    }

    public void ChangeBullet(GameObject bullet, float shootDelay, float duration)
    {
        //Set the power up weapon into the current settings
        currentBullet = bullet;
        currentShootDelay = shootDelay;

        //Starts a function that counts down the powerup duration
        StartCoroutine(DefaultBullet(duration));
    }

    //defaults the current settings back into the default after a set duration
    IEnumerator DefaultBullet(float duration)
    {
        yield return new WaitForSeconds(duration);
        currentBullet = defaultBullet;
        currentShootDelay = defaultShootDelay;
    }
}
