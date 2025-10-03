using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circleOfSquares : MonoBehaviour
{
    public int cubeCount = 10;
    public float radius = 5f;

    void Start()
    {
        for (int i = 0; i < cubeCount; i++)
        {
            float angle = i * Mathf.PI * 2 / cubeCount;
            float x = Mathf.Cos(angle) * radius;
            float z = Mathf.Sin(angle) * radius;

            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

            cube.transform.position = new Vector3(x, 0, z);
        }
    }
}
