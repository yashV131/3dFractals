using UnityEngine;

public class CrossMenger : MonoBehaviour//Creates a Snowflake
{
    public int recursionDepth = 3;
    public float size = 3f;
    public Material redMaterial;
    public float rotationSpeedX = 10f;
    public float rotationSpeedY = 10f;

    private GameObject parentObject; 

    void Start()
    {
        if (redMaterial == null)
        {
            Debug.LogError("Red material is not assigned!");
            return;
        }

        parentObject = new GameObject("CrossMengerParent");

        GenerateCrossedMenger(Vector3.zero, size, recursionDepth);
    }

    void Update()
    {
        parentObject.transform.Rotate(Vector3.right * rotationSpeedX * Time.deltaTime);
        parentObject.transform.Rotate(Vector3.up * rotationSpeedY * Time.deltaTime);
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
                      
                        if (!(x == 0 || y == 0 || z == 0))
                        {
                            Vector3 newPosition = position + new Vector3(x, y, z) * newSize;
                            GenerateCrossedMenger(newPosition, newSize, depth - 1);//recursive call
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

        cube.transform.SetParent(parentObject.transform);
    }
}
