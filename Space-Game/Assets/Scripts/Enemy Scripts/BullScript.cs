using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullScript : MonoBehaviour
{
    private Rigidbody rb;
    private SphereCollider horn;

    public float thrust;
    public float pointOfContact;
    public float slowDown;

    public GameObject explosionEffect;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    public void Forward()
    {
        rb.AddForce(transform.forward * thrust * -1);
    }

    public void Stop()
    {
        Vector3 stoptarget = new Vector3(0,0,0);
        while(rb.velocity != stoptarget)
        {
            rb.velocity = Vector3.Lerp(rb.velocity, stoptarget, slowDown) * Time.deltaTime;
        }
        Debug.Log("Stopped");
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            //Move the bull towards the player
            Debug.Log("Thrusting");
            Forward();

            //Calculate the distance between collider and object
            Vector3 closestPoint = other.ClosestPoint(transform.position);
            float distance = Vector3.Distance(closestPoint, transform.position);
            if(distance <= pointOfContact)
            {
                //Do Damage based on velocity
                float damage = (rb.velocity * rb.mass).magnitude;
                //Damage script goes here
                Debug.Log(damage);
                //Explode
                Explode();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            //Stop velocity
            Stop();
        }
    }

    void Explode()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);

        Destroy(gameObject);
    }

}
