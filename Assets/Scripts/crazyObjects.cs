using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class crazyObjects : MonoBehaviour
{
    private GameObject box, box2, sphere1, capsule1, scalingCube, stretchingSphere;
    public Material matRainbow;

    private Color startColor = new Color(255f, 255f, 255f);
    private Color endColor = new Color(255f, 0f, 0f);
    private float changeColorBetween = 0.5f;
    private float changeColorNext;

    void Awake()
    {
        box = GameObject.CreatePrimitive(PrimitiveType.Cube);
        box.transform.position = new Vector3(0, 0, 0);
        box.transform.localScale = new Vector3(2f, 2f, 2f);

        box2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        box2.transform.position = new Vector3(5, 0, 0);
        box2.transform.localScale = new Vector3(1f, 1f, 1f);

        sphere1 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere1.transform.position = new Vector3(0, 5, 0);
        sphere1.transform.localScale = new Vector3(1f, 1f, 1f);

        capsule1 = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        capsule1.transform.position = new Vector3(5, 0, 5);
        capsule1.transform.localScale = new Vector3(1f, 1f, 1f);

        scalingCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        scalingCube.transform.position = new Vector3(-20, 0, 0);
        scalingCube.transform.localScale = new Vector3(1f, 1f, 1f);

        stretchingSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        stretchingSphere.transform.position = new Vector3(10, 0, 0);
        stretchingSphere.transform.localScale = new Vector3(1f, 1f, 1f);

        box.GetComponent<Renderer>().material = matRainbow;
        changeColorNext = Time.time + changeColorBetween;

        box2.GetComponent<Renderer>().material = matRainbow;
        changeColorNext = Time.time + changeColorBetween;

        MaterialPropertyBlock shinyMat = new MaterialPropertyBlock();
        shinyMat.SetFloat("_Smoothness", 1.0f);
        shinyMat.SetFloat("_Metallic", 1.0f);

        sphere1.GetComponent<Renderer>().material = matRainbow;
        sphere1.GetComponent<Renderer>().SetPropertyBlock(shinyMat);

        capsule1.GetComponent<Renderer>().material = matRainbow;
        capsule1.GetComponent<Renderer>().SetPropertyBlock(shinyMat);

        scalingCube.GetComponent<Renderer>().material = matRainbow;
        stretchingSphere.GetComponent<Renderer>().material = matRainbow;
    }

    void Update()
    {
        if (box != null)
        {
            float x = Time.time * 50f;
            float y = Time.time * 50f;
            float z = Time.time * 50f;
            box.transform.rotation = transform.rotation * Quaternion.Euler(x, y, z);
            box2.transform.RotateAround(box.transform.position, Vector3.up, 50 * Time.deltaTime);

            matRainbow.color = Color.Lerp(startColor, endColor, Mathf.PingPong(Time.time, 1));

            if (changeColorNext <= Time.time)
            {
                startColor = endColor;
                endColor = new Color(UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f));

                changeColorNext = Time.time + changeColorBetween;
            }

            sphere1.transform.RotateAround(box.transform.position, Vector3.right, 150 * Time.deltaTime);
            capsule1.transform.RotateAround(box.transform.position, Vector3.forward, 20 * Time.deltaTime);

            float diamondSpeed = 2.0f;
            float diamondRange = 5.0f;
            float diamondX = Mathf.PingPong(Time.time * diamondSpeed, diamondRange);
            float diamondZ = Mathf.PingPong(Time.time * diamondSpeed + (diamondRange / 2), diamondRange);

            scalingCube.transform.position = new Vector3(diamondX - (diamondRange / 2), diamondZ - (diamondRange / 2), 0);

            float scaleValue = Mathf.PingPong(Time.time, 1.5f) + 0.5f;
            scalingCube.transform.localScale = new Vector3(scaleValue, scaleValue, scaleValue);
            scalingCube.transform.rotation = transform.rotation * Quaternion.Euler(x, y, z);

            float stretchValue = Mathf.PingPong(Time.time * 2, 2.0f) + 0.5f;
            stretchingSphere.transform.localScale = new Vector3(stretchValue, 1f, stretchValue);
        }
    }
}
