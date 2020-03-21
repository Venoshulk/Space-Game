using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullScript : MonoBehaviour
{
    private Rigidbody rb;
    private SphereCollider horn;

    public float thrust;
    public float pointOfContact;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    public void Forward()
    {
        rb.AddForce(transform.forward * thrust * -1);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Calculate the distance between collider and object
        Vector3 closestPoint = other.ClosestPoint(transform.position);
        float distance = Vector3.Distance(closestPoint, transform.position);

        if (other.tag == "Player" && distance <= pointOfContact)
        {
            //Do Damage based on velocity
            Vector3 damage = rb.velocity;
            //Damage script goes here
            Debug.Log(damage);
            //Explode
            Explode();
        }
    }

    void Explode()
    {
        Destroy(gameObject);
    }

}
