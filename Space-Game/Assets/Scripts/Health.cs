
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    private const float DEAD = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 100.0f;
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= DEAD)
        {
            //Dead code here
        }
    }
}