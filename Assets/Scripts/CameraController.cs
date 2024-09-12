using UnityEngine;

//This class helps magnify/minimize the fractal
public class CameraController : MonoBehaviour
{
    public float rotationSpeed = 100f; // Speed of camera rotation
    public float zoomSpeed = 10f;      // Speed of zoom
    public float panSpeed = 0.5f;      // Speed of panning

    private Vector3 lastMousePosition;

    void Update()
    {
        HandleMouseRotation();
        HandleMouseZoom();
        HandleMousePanning();
    }
    void HandleMouseRotation()
    {
        if (Input.GetMouseButton(1)) 
        {
            float rotationX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
            float rotationY = Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;

            transform.RotateAround(Vector3.zero, Vector3.up, -rotationX);
            transform.RotateAround(Vector3.zero, transform.right, rotationY);
        }
    }

    void HandleMouseZoom()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        transform.Translate(0, 0, scroll);  
    }

   
    void HandleMousePanning()
    {
        if (Input.GetMouseButton(2)) 
        {
            Vector3 delta = Input.mousePosition - lastMousePosition;
            Vector3 translation = new Vector3(-delta.x, -delta.y, 0) * panSpeed * Time.deltaTime;

          
            transform.Translate(translation);
        }
        lastMousePosition = Input.mousePosition;
    }
}
