using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVariables : Health
{
    void Start()
    {
        maxHealth = 100.0f;
        currentHealth = maxHealth;
    }
    void Update()
    {
        CheckHealth();
    }
    protected override void CheckHealth()
    {
        if (currentHealth <= DEAD)
        {
            //Dead code here
            Death();
            Debug.Log("Retired");
        }
    }
}
