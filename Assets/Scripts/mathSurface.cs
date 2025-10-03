using UnityEngine;

public class mathSurface : MonoBehaviour
{
    public int gridSize = 20;
    public float valueRange = 5.0f;
    public float heightScale = 0.5f;
    private GameObject[ , ] spheres = new GameObject[20, 20];

    void Start()
    {

        float step = (2f * valueRange) / (gridSize - 1);
        float maxOriginalY = Mathf.Pow(valueRange, 2) + Mathf.Pow(valueRange, 2);
        float maxY = maxOriginalY * heightScale;

        for (int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                float x = j * step - valueRange;
                float z = i * step - valueRange;

                float y = Mathf.Pow(x, 2) + Mathf.Pow(z, 2);

                y *= heightScale;

                GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                Material instanceMaterial = new Material(Shader.Find("Standard"));
                sphere.GetComponent<Renderer>().material = instanceMaterial;
                float normalizedHeight = y / maxY;
                instanceMaterial.color = Color.Lerp(Color.green, Color.red, normalizedHeight);


                sphere.transform.localScale = Vector3.one * 0.5f;
                sphere.transform.position = new Vector3(x, y, z);
                sphere.transform.parent = this.transform;

                spheres[i, j] = sphere;
            }
        }
    }

    void Update() {
        float scaleAmount = 0.5f + (Mathf.Sin(Time.time * 4.0f) * 0.2f);
        scaleAmount = Mathf.Max(0.01f, scaleAmount);

        for (int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                GameObject sphere = spheres[i, j];
                sphere.transform.localScale = Vector3.one * scaleAmount;
            }
        }
    }
}

