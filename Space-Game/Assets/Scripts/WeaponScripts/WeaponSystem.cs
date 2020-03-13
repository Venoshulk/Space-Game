using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{

    public GameObject defaultGun;
    private GameObject currentGun;
    // Start is called before the first frame update
    void Start()
    {
        //Reset the weapons
        foreach(Transform weapon in transform)
        {
            weapon.gameObject.SetActive(false);
        }
        //Select the default Gun
        currentGun = defaultGun;
        defaultGun.gameObject.SetActive(true);
    }
    public void SelectWeapon(GameObject desiredGun)
    {
        currentGun.gameObject.SetActive(false); //disables current gun

        currentGun = desiredGun;
        currentGun.gameObject.SetActive(true);
    }
}
