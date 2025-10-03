using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeArray : MonoBehaviour
{
    public GameObject[,] cubeArray5x5 = new GameObject[5, 5];

    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.transform.position = new Vector3(j * 2, i * 2, 0);
                cubeArray5x5[i, j] = cube;
            }
        }
    }
}
