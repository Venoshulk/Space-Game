using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVariables : Health
{
    private int _score;

    void Start()
    {
        maxHealth = 100.0f;
        currentHealth = maxHealth;
        _score = 100;
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
            PlayerScore.ModifyScore(_score);
            Debug.Log("Score after enemy: " + PlayerScore.GetScoreValue());
            Death();
            Debug.Log("Retired!!!");
            Debug.Log("AWOOOOOOOOOOOOOGA");
            Debug.Log("Log messages are fun, yeet.");
            Debug.Log("Retired");
        }
    }
}
