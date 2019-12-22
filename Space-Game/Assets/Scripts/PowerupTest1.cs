using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupTest1 : Powerups
{
    //Properties
    private int _Time = 5;

    //Constructor
    public PowerupTest1()
    {   SetTimer(_Time);
    }

    //Check for collision, if so, apply power up.
    void OnTriggerEnter(Collider other)
    {   Debug.Log("Is Player?");
        if(other.CompareTag("Player"))          //Check collision by collider's tag.
        {   Debug.Log("Power up!");
            StartCoroutine(ApplyEffects());     //StartCoroutine is required in order to call IEnumerator.
        }
    }

    //Apply powerup for X time, and then remove effects.
    IEnumerator ApplyEffects()
    {   Debug.Log("Powered up!");
        yield return new WaitForSeconds(GetTimer());        //Before removing buffs, wait.
        Debug.Log("Powered up off!");
        //Destroy powerup on field.
        Destroy(gameObject);                                //Remove the object.
    } 
}