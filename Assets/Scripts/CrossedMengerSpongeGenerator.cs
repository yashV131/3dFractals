using UnityEngine;

//This creates an Anti-Cross-Menger
public class CrossedMengerSpongeGenerator : MonoBehaviour
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

        spongeParent = new GameObject("CrossedMengerSpongeParent");
        spongeParent.transform.position = Vector3.zero;
        spongeParent.transform.SetParent(transform);

        GenerateCrossedMenger(Vector3.zero, size, recursionDepth);
    }

    void Update()
    {
       
        if (spongeParent != null)
        {
            spongeParent.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
            spongeParent.transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);
        }
    }

    void GenerateCrossedMenger(Vector3 position, float currentSize, int depth)
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
                        if (x == 0 || y == 0 || z == 0)
                        {
                            Vector3 newPosition = position + new Vector3(x, y, z) * newSize;
                            GenerateCrossedMenger(newPosition, newSize, depth - 1);//normal recursion
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
        cube.GetComponent<Renderer>().material = redMaterial;

        if (spongeParent != null)
        {
            cube.transform.SetParent(spongeParent.transform);
        }
    }
}
