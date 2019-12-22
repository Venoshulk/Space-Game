using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public GameObject player;
    public GameObject PowerUpWeapon;
    public GameObject PowerUpBullet;

    private void OnTriggerEnter(Collider other) //checks for sphere collisions
    {
        if(other.gameObject == player) //checks for player collision
        {
            other.gameObject.GetComponent<PlayerWeapons>().currentWeapon.deleteWeapon(); //Deletes old weapon graphic
            PlayerWeapons.Weapon RocketLauncher = new PlayerWeapons.Weapon(0.5f, PowerUpWeapon, PowerUpBullet); //creates a new weapon object
            other.gameObject.GetComponent<PlayerWeapons>().currentWeapon = RocketLauncher; //sets current weapon to the created object
            Destroy(this.gameObject);
        }
    }
}
