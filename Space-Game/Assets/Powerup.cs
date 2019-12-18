using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            other.gameObject.GetComponent<PlayerWeapons>().currentWeapon.shootDelay = 5.0f;
            Destroy(this.gameObject);
        }
    }
}
