using UnityEngine;

public class VertPad : MonoBehaviour
{
    public float force;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<Rigidbody>() != null)
        {
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();

            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            rb.AddForce(Vector3.up * force, ForceMode.Impulse);
        }
    }
}
