using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeLevel : MonoBehaviour
{
    private Vector3[] vecList;
    public int objectAmount = 1;
    public GameObject plane;
    public GameObject prefab;
    public float standardHeight = 0f;
    void Start()
    {
        vecList = new Vector3[objectAmount];
        Bounds planeBounds = plane.GetComponent<MeshCollider>().bounds;
        Vector3 bounds = new Vector3(planeBounds.size.x / 2, 0, planeBounds.size.z / 2);

        for (int i = 0; i < vecList.Length; i++) {
            // Debug.Log("x: " + planeBounds.size.x + " z: " + planeBounds.size.z);
            vecList[i] = new Vector3(Random.Range(-1 * bounds.x, bounds.x), standardHeight, Random.Range(-1 * bounds.z, bounds.z));

            Debug.Log(vecList[i].x + " " + vecList[i].z);

            Instantiate(prefab, vecList[i], Quaternion.Euler(0, 0, 0), transform);
        }

    }

    void Update()
    {
        
    }
}
