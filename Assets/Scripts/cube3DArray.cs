using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube3DArray : MonoBehaviour
{
    public GameObject[,,] cubeArray5x5 = new GameObject[5, 5, 5];

    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                for (int k = 0; k < 5; k++)
                {
                    GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    cube.transform.position = new Vector3(j * 2, i * 2, k * 2);
                    cubeArray5x5[i, j, k] = cube;
                }
            }
        }
    }
}
