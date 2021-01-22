using System.Collections.Generic;
using UnityEngine;

public class EnvironmentCreator : MonoBehaviour
{
    public List<GameObject> types = new List<GameObject>();
    public float radius = 500f;
    public int numberToSpawn = 1000;

    public Vector3 sizesMin = new Vector3(1f, 1f, 1f);
    public Vector3 sizesMax = new Vector3(10f, 100f, 10f);

    public int seed;

    void Start()
    {
        if(types.Count == 0)
        {
            return;
        }

        Random.InitState(seed);

        for (int i=0; i<numberToSpawn; i++)
        {
            int iType = Random.Range(0, types.Count);

            Vector2 position2d = Random.insideUnitCircle * radius;

            Vector3 size = new Vector3(
                Random.Range(sizesMin.x, sizesMax.x),
                Random.Range(sizesMin.y, sizesMax.y),
                Random.Range(sizesMin.z, sizesMax.z)
            );

            Vector3 position3d = new Vector3(position2d.x, size.y / 2f, position2d.y);
            Quaternion rotation = Quaternion.Euler(0f, Random.Range(0f, 360f), 0f);

            GameObject instance = Instantiate(types[iType], position3d, rotation);
            instance.transform.localScale = size;

            instance.GetComponent<MeshRenderer>().material.color = new Color(
                1f * 0.5f + Random.value * 0.5f,
                1f * 0.5f + Random.value * 0.5f,
                1f * 0.5f + Random.value * 0.5f,
                1f
            );
        }
    }

    
}
