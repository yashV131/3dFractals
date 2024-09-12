using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Fractals : MonoBehaviour//GreekCross code
{
    public Mesh mesh;
    public Material material;
    public int max_depth;
    private int depth;
    public float childScale;
    public float maxRotationSpeed;
    private float rotationSpeed;
    void Start()
    {
        rotationSpeed = Random.Range(-maxRotationSpeed, maxRotationSpeed);
        gameObject.AddComponent<MeshFilter>().mesh = mesh;
        MeshRenderer renderer = gameObject.AddComponent<MeshRenderer>();

        renderer.sharedMaterial = material;
        GetComponent<MeshRenderer>().material.color = Color.Lerp(Color.black, Color.red, Mathf.PingPong(Time.time, 1));
        //recursion using StartCoroutine() -  If the depth is still less than max_depth - 1,
        //the CreateChildren method is called again for each child GameObject,
        //which will repeat the proces
        if (depth < max_depth - 1)
        {
            StartCoroutine(CreateChildren());
        }

    }

    private IEnumerator CreateChildren()
    {
        Vector3[] directions = new Vector3[] {
        new Vector3(0, 1, 0),
        new Vector3(0, 0, 1),
        new Vector3(1, 0, 0),
        new Vector3(-1, 0, 0),
       new Vector3(0, -1, 0),
        new Vector3(0, 0, -1)
    };

        for (int i = 0; i < directions.Length; i++)
        {
            GameObject child = new GameObject($"Fractal Child {i + 1}");
            child.AddComponent<Fractals>().Initialize(this, directions[i]);
            yield return new WaitForSeconds(0.5f);
        }
    }
    private void Initialize(Fractals parent, Vector3 direction)
    {
        mesh = parent.mesh;
        material = parent.material;
        max_depth = parent.max_depth;
        depth = parent.depth + 1;
        childScale = parent.childScale;
        transform.parent = parent.transform;
        maxRotationSpeed = parent.maxRotationSpeed;
        transform.localScale = new Vector3(1, 1, 1) * childScale;
        transform.localPosition = direction * (0.5f + 0.5f * childScale);
    }

    // Update is called once per frame 
    void Update()
    {
        transform.Rotate(0.1f, rotationSpeed * Time.deltaTime, 0f);


    }
}
