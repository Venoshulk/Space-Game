﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*  THIS IS AN EXAMPLE OF A CHILD INSTANCE OF THE POEWRUPS CLASS THAT POWERS UP FOR A GIVEN TIME.   */


public class PowerupsTemp : Powerups            //Inherites from the powerups class.
{
    //Properties
    private int _Duration = 8;                  //In seconds, hown long this will last.
    private double _Multiplier = 1.5;           //The multiplier applied and divided to a stat.
    private int _ThisScoreValue = 30;           //Score value for collecting this powerup. *TEMP*
    PlayerMovement Player;                      //The player itself.

    //Constructor (Start)
    public void Start()
    {   SetMultiplier(_Multiplier);
        SetThisScoreValue(_ThisScoreValue);
        SetTimer(_Duration);                    //Set the duration of the temporary powerup.
    }

    //Methods
    void OnTriggerEnter(Collider other)         //Check for collision, if so, apply power up.
    {   if (other.CompareTag("Player"))         //Check collision by collider's tag.
        {   Debug.Log("Power up!");
            Player = other.GetComponent<PlayerMovement>();
            StartCoroutine(ApplyEffects());     //StartCoroutine is required in order to call IEnumerator.
            AddThisScore();
        }
    }

    IEnumerator ApplyEffects()                  //Apply powerup, after player collison for X time, and then remove effects.
    {   PowerUp();
        Destroy(gameObject);                                //Remove this powerup.
        yield return new WaitForSeconds(GetTimer());        //Before removing buffs, wait.
        PowerDown();
    } 

    private void PowerUp()                      //Method unique per powerup, here is the actual power up.
    {   Player.fuelThrust = Player.fuelThrust * (float)GetMultiplier();
        Debug.Log("Powered up!");
    }

    private void PowerDown()                    //Powers down after timer, respective to PowerUp's multiplier.
    {   Player.fuelThrust = Player.fuelThrust / (float)GetMultiplier();
        Debug.Log("Powered up off!");
    }
}