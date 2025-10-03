using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public bool isGrounded;
    Rigidbody rb;

    private PointHUD pointHUD;

    public AudioClip collectSound;
    private AudioSource audioSource;

    void Start(){
        rb = GetComponent<Rigidbody>();
        audioSource = gameObject.AddComponent<AudioSource>();
        pointHUD = FindObjectOfType<PointHUD>();
    }

    void OnCollisionStay(Collision collision)
    {
        isGrounded = true;
    }

    void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded){
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveX, 0, moveZ);
        rb.AddForce(movement * moveSpeed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            audioSource.PlayOneShot(collectSound);
            pointHUD.Points++;
            Destroy(other.gameObject);
        }
    }
}
