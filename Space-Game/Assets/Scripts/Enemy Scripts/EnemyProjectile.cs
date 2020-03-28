using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : Projectile
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        if (other.tag == "Player")
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
}
