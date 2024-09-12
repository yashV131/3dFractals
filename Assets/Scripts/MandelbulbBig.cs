using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This creates the MandelBulb, it is not a part of the main project
public class MandelbulbBig : MonoBehaviour
{
    public int maxIterations = 50;
    public float threshold = 4.0f;
    public float bailout = 2.0f; 
    public int resolution = 50; 
    public float scale = 2.0f;  
    public GameObject spherePrefab;  
    void Start()
    {
        GenerateMandelbulb();
    }

    void GenerateMandelbulb()
    {
        for (int x = -resolution; x <= resolution; x++)
        {
            for (int y = -resolution; y <= resolution; y++)
            {
                for (int z = -resolution; z <= resolution; z++)
                {
                    Vector3 point = new Vector3(x, y, z) / scale;

                    if (MandelbulbIteration(point))
                    {
                      
                        Instantiate(spherePrefab, point * scale, Quaternion.identity);
                    }
                }
            }
        }
    }

   
    bool MandelbulbIteration(Vector3 point)
    {
        Vector3 z = point;
        int iteration = 0;

        while (z.sqrMagnitude < threshold && iteration < maxIterations)
        {
            z = MandelbulbPower(z) + point;  
            iteration++;
        }

        return iteration == maxIterations;
    }

  
    Vector3 MandelbulbPower(Vector3 z)
    {
        float r = z.magnitude;  
        float theta = Mathf.Acos(z.z / r); 
        float phi = Mathf.Atan2(z.y, z.x); 

        float r8 = Mathf.Pow(r, 8);
        float theta8 = theta * 8;
        float phi8 = phi * 8;

        float x = r8 * Mathf.Sin(theta8) * Mathf.Cos(phi8);
        float y = r8 * Mathf.Sin(theta8) * Mathf.Sin(phi8);
        float z_new = r8 * Mathf.Cos(theta8);

        return new Vector3(x, y, z_new);
    }
}
