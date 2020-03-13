using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToPlayer : MonoBehaviour
{
    GameObject target;
    Vector3 direction;
    Quaternion rotation;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //Rotate object towards target
        direction = target.transform.position - transform.position;
        rotation = Quaternion.LookRotation(direction * -1);
        transform.rotation = rotation;
    }
}
