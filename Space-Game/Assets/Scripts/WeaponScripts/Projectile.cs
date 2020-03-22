using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody rb;
    public float thrust;
    public float duration;
    public float pointOfContact;
    public float bulletDamage;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        OnInstance();
        StartCoroutine(BulletDeath());
    }
    //On collision with another object
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            Vector3 closestPoint = other.ClosestPoint(transform.position);
            Debug.Log("Close: " + closestPoint);
            float distance = Vector3.Distance(closestPoint, other.transform.position);
            Debug.Log("Distance " + distance);
            if (distance <= pointOfContact)
            {
                //Cause damage
                other.GetComponent<Health>().Damage(bulletDamage);
                DestroyBullet();
            }
        }
    }
    //On creation function
    void OnInstance()
    {
        rb.AddForce(transform.forward * thrust);
    }
    //Waits for a duration then executes a destroy function
    IEnumerator BulletDeath()
    {
        yield return new WaitForSeconds(duration);
        DestroyBullet();
    }

    void DestroyBullet()
    {
        Object.Destroy(gameObject);
    }
}
