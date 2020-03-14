using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody rb;
    public float thrust;
    public float duration;
    public float bulletDamage;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        OnInstance();
        StartCoroutine(StartDeath());
    }
    //On collision with another object
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            //Cause damage -> Not yet implemented
            DestroyBullet();
        }
        else if(other.tag == "Planet")
        {
            //Get component of script, change health variable
            other.gameObject.GetComponent<Planetexplode>().DoDamage(bulletDamage);
            DestroyBullet();
        }
    }
    //On creation function
    void OnInstance()
    {
        rb.AddForce(transform.forward * thrust);
    }

    IEnumerator StartDeath()
    {
        yield return new WaitForSeconds(duration);
        DestroyBullet();
    }

    void DestroyBullet()
    {
        Object.Destroy(gameObject);
    }
}
