using UnityEngine;

public class PaddleSpawner : MonoBehaviour
{
    public GameObject paddle;
    public int numberOfPaddles;
    public float spawnRangeX;
    public float spawnRangeZ;
    public float padHeightY;

    void Start()
    {
        SpawnPads();
    }

    void SpawnPads()
    {
        for (int i = 0; i < numberOfPaddles; i++)
        {
            float randomX = Random.Range(-spawnRangeX, spawnRangeX);
            float randomZ = Random.Range(-spawnRangeZ, spawnRangeZ);

            Vector3 spawnPosition = new Vector3(randomX, padHeightY, randomZ);
            Instantiate(paddle, spawnPosition, Quaternion.identity);
        }
    }
}
