using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBackPlayer : MonoBehaviour
{
    private float knockbackStrength = 30.0f;
    private void OnCollisionEnter(Collision collision)
    {
        
            Rigidbody rb = collision.collider.GetComponent<Rigidbody>();

            Debug.Log("i HIT " + collision.gameObject.tag);
        // if rigid body collides with a game object tagged Enemy
            if (rb != null && collision.gameObject.tag == "Enemy")
            {
            //how rigid body force is applied once if is excuted 
                Vector3 direction = collision.transform.position - transform.position;
                direction.y = 0;

                rb.AddForce(direction.normalized * knockbackStrength, ForceMode.Impulse);
            }
        }
}
