using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    //variable of how srong the rigid body force will be 
    public float knockbackStrength = 50.0f;
    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody rb = collision.collider.GetComponent<Rigidbody>();
        //if the rigid body hits a player it does the sequence underneath
        if (rb != null && collision.gameObject.tag == "Player")
        {
            //direction of knockback 
            Vector3 direction = collision.transform.position - transform.position;
            direction.y = 0;
            //how knockback is calculated and done
            rb.AddForce(direction.normalized * knockbackStrength, ForceMode.Impulse);
        }
    }
}
