using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody rb;
    public float thrust;
    public float duration;
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
            //Cause damage -> Not yet implemented
<<<<<<< HEAD:Space-Game/Assets/Bullets/Projectile.cs
            Debug.Log("Yes!");
            other.GetComponent<Health>().Damage(789);
=======
            Debug.Log(other.gameObject.name);
            DestroyBullet();
>>>>>>> 1d1eaf028b21706578fd9e473d8f221e018451b6:Space-Game/Assets/Scripts/WeaponScripts/Projectile.cs
        }
        DestroyBullet();
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
