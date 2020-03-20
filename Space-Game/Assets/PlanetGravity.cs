using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetGravity2 : MonoBehaviour
{
    public int GravForce;

    private GameObject ObjectToPull;

    private void Start()
    {
        ObjectToPull = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == ObjectToPull)
        {
            Rigidbody PlayerRB = other.gameObject.GetComponent<Rigidbody>();

            PlayerRB.AddForce((transform.position - ObjectToPull.transform.position).normalized * GravForce * Time.smoothDeltaTime);
            //Debug.Log("penis");
        }
    }
}
