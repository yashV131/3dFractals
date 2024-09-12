using UnityEngine;

//This helper class helps rotate the fractal group
public class GroupRotator : MonoBehaviour
{
    public float rotationSpeed = 10.0f;

    void Update()
    {
        
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
