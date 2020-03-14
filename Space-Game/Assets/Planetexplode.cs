using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planetexplode : MonoBehaviour
{
    public float planetHealth = 35;

    // Start is called before the first frame update
    void Start()
    {
        planetHealth = 35;
    }

    public void DoDamage(float bulletDamage)
    {
        planetHealth -= bulletDamage;

        if (planetHealth<=0)
        {
            BlowUp();
        }
    }

    void BlowUp ()
    {
        Object.Destroy(gameObject);
    }
}
