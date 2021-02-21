using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeLevel : MonoBehaviour
{
    private Vector3[] vecList;
    public int hideableObjectAmount = 10;
    public GameObject referenceSizePlane;
    public GameObject characterPrefab;
    public float standardHeight = 0f;
    public void Start()
    {
        vecList = new Vector3[hideableObjectAmount];
        Bounds planeBounds = referenceSizePlane.GetComponent<MeshCollider>().bounds;
        Vector3 bounds = new Vector3(planeBounds.size.x / 2, 0, planeBounds.size.z / 2);

        int activeIndex = Random.Range(0, hideableObjectAmount);
        Debug.Log(activeIndex);

        for (int i = 0; i < vecList.Length; i++) {
            vecList[i] = new Vector3(Random.Range(-1 * bounds.x, bounds.x), standardHeight, Random.Range(-1 * bounds.z, bounds.z));
            GameObject hideable = Instantiate(characterPrefab, vecList[i], Quaternion.Euler(0, 0, 0), transform.GetChild(0));
            if (i == activeIndex) {
                hideable.GetComponent<FriendCharacter>().SetCharacterActive(true);
            }

        }

    }
}
