using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*  THIS IS AN EXAMPLE OF A CHILD INSTANCE OF THE POWER UPS CLASS THAT PERMANENTLY POWERS UP.   */

public class PowerupTest2 : Powerups
{
    //Properties
    private double Boost = 20;                  //The multiplier applied and divided to a stat.
    PlayerMovement Player;                      //The player itself.

    //Constructor
    public PowerupTest2()
    {   SetMultiplier(Boost);
    }

    //Methods
    void OnTriggerEnter(Collider other)         //Check for collision, if so, apply power up.
    {   Debug.Log("Is Player?");
        if (other.CompareTag("Player"))         //Check collision by collider's tag.
        {   Debug.Log("Power up!");
            Player = other.GetComponent<PlayerMovement>();
            ApplyEffects(); 
        }
    }

    private void ApplyEffects()      //Apply powerup, after player collison for X time, do not remove effects.
    {   PowerUp();
        Destroy(gameObject);                                //Remove the object.
    }

    private void PowerUp()                      //Method unique per powerup, here is the actual power up.
    {   Player.fuelThrust = Player.fuelThrust + (float)GetMultiplier();
        Debug.Log("Powered up!" + Player.fuelThrust);
    }
}
