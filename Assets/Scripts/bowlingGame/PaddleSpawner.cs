using UnityEngine;
using System.Collections;

public class paddleSpawner : MonoBehaviour
{
    public GameObject paddle;
    public int numberOfPaddles;
    public float padHeightY;
    public float moveSpeed;
    public float forceApplicationInterval;
    public float boundaryX;
    public float boundaryZ;

    void Start()
    {
        for (int i = 0; i < numberOfPaddles; i++)
        {
            float randomX = Random.Range(-boundaryX, boundaryX);
            float randomZ = Random.Range(-boundaryZ, boundaryZ);

            Vector3 spawnPosition = new Vector3(randomX, padHeightY, randomZ);
            GameObject newPaddle = Instantiate(paddle, spawnPosition, Quaternion.identity);

            StartCoroutine(MovePaddleRandomly(newPaddle));
        }
    }

    IEnumerator MovePaddleRandomly(GameObject p)
    {
        Rigidbody rb = p.GetComponent<Rigidbody>();

        while(true)
        {
            if(p == null) {
                yield break;
            }

            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            float randomX = Random.Range(-1f, 1f);
            float randomZ = Random.Range(-1f, 1f);
            Vector3 randomDirection = new Vector3(randomX, 0, randomZ).normalized;

            rb.AddForce(randomDirection * moveSpeed, ForceMode.VelocityChange);

            yield return new WaitForSeconds(forceApplicationInterval);

            while (rb.velocity.magnitude > 0)
            {
                Vector3 currentPos = p.transform.position;
                bool needsCorrection = false;

                if (currentPos.x > boundaryX)
                {
                    currentPos.x = boundaryX;
                    rb.velocity = new Vector3(-Mathf.Abs(rb.velocity.x), 0, rb.velocity.z);
                    needsCorrection = true;
                }
                else if (currentPos.x < -boundaryX)
                {
                    currentPos.x = -boundaryX;
                    rb.velocity = new Vector3(Mathf.Abs(rb.velocity.x), 0, rb.velocity.z);
                    needsCorrection = true;
                }

                if (currentPos.z > boundaryZ)
                {
                    currentPos.z = boundaryZ;
                    rb.velocity = new Vector3(rb.velocity.x, 0, -Mathf.Abs(rb.velocity.z));
                    needsCorrection = true;
                }
                else if (currentPos.z < -boundaryZ)
                {
                    currentPos.z = -boundaryZ;
                    rb.velocity = new Vector3(rb.velocity.x, 0, Mathf.Abs(rb.velocity.z));
                    needsCorrection = true;
                }

                if (needsCorrection)
                {
                    p.transform.position = new Vector3(currentPos.x, padHeightY, currentPos.z);
                }

                yield return new WaitForFixedUpdate();
            }
        }
    }
}
