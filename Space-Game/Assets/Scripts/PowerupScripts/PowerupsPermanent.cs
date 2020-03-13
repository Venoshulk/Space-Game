using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*  THIS IS AN EXAMPLE OF A CHILD INSTANCE OF THE POWER UPS CLASS THAT PERMANENTLY POWERS UP.   */


public class PowerupsPermanent : Powerups
{
    //Properties
    private double _Multiplier = 40;            //The multiplier applied and divided to a stat.
    private int _ThisScoreValue = 10;           //Score value for collecting this powerup. *TEMP*
    PlayerMovement Player;                      //The player itself.

    //Constructor (Start)
    public void Start()
    {   SetMultiplier(_Multiplier);
        SetThisScoreValue(_ThisScoreValue);
    }

    //Methods
    void OnTriggerEnter(Collider other)         //Check for collision, if so, apply power up.
    {   if (other.CompareTag("Player"))         //Check collision by collider's tag.
        {   Debug.Log("Power up!");
            Player = other.GetComponent<PlayerMovement>();
            ApplyEffects();
            AddThisScore();
        }
    }

    private void ApplyEffects()                 //Apply powerup, after player collison for X time, do not remove effects.
    {   PowerUp();
        Destroy(gameObject);                    //Remove this powerup immediately afterwards.
    }

    private void PowerUp()                      //Method unique per powerup, here is the actual power up.
    {   Player.fuelThrust = Player.fuelThrust + (float)GetMultiplier();
        Debug.Log("Powered up!" + Player.fuelThrust);
    }
}
