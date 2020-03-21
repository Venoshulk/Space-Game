
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float maxHealth;
    private float currentHealth;
    private const float DEAD = 0.0f;
    private Text healthBox;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 100.0f;
        currentHealth = maxHealth;
        healthBox = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= DEAD)
        {
            //Dead code here
        }
        else
        {
            healthBox.text = currentHealth.ToString();
        }
    }
}