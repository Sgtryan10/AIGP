using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pad : MonoBehaviour
{
    public float force;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<Rigidbody>() != null)
        {

            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            rb.AddForce(Vector3.up * force + rb.velocity, ForceMode.Impulse);
        }
    }
}
