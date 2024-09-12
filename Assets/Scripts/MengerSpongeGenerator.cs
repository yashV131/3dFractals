using System.Collections.Generic;
using UnityEngine;

//This class creates a normal Menger Sponge
public class MengerSpongeGenerator : MonoBehaviour
{
    public int recursionDepth = 3;
    public float size = 3f;
    public Material redMaterial;
    public float rotationSpeed = 30f; 

    private GameObject spongeParent;

    void Start()
    {
        if (redMaterial == null)
        {
            Debug.LogError("Red material is not assigned!");
            return;
        }


        spongeParent = new GameObject("MengerSpongeParent");
        spongeParent.transform.position = Vector3.zero;
        spongeParent.transform.SetParent(transform);

        GenerateMengerSponge(Vector3.zero, size, recursionDepth);
    }

    void Update()
    {
        if (spongeParent != null)
        {
            spongeParent.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
            spongeParent.transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);

        }
    }

    void GenerateMengerSponge(Vector3 position, float currentSize, int depth)
    {
        if (depth == 0)
        {
            CreateCube(position, currentSize);
        }
        else
        {
            float newSize = currentSize / 3f;
            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    for (int z = -1; z <= 1; z++)
                    {
                        int absX = Mathf.Abs(x), absY = Mathf.Abs(y), absZ = Mathf.Abs(z);
                        if ((absX + absY + absZ) > 1)
                        {
                            Vector3 newPosition = position + new Vector3(x, y, z) * newSize;
                            GenerateMengerSponge(newPosition, newSize, depth - 1);//normal recursion
                        }
                    }
                }
            }
        }
    }

    void CreateCube(Vector3 position, float size)
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = position;
        cube.transform.localScale = Vector3.one * size;
        if (redMaterial != null)
        {
            cube.GetComponent<Renderer>().material = redMaterial;
        }

        
        if (spongeParent != null)
        {
            cube.transform.SetParent(spongeParent.transform);
        }
    }
}
