using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    // public Camera cam;
    void Start()
    {

    }

    void Update()
    {
        Camera cam = Camera.main;
        
        Vector3 direction = cam.transform.position - transform.position;
        direction.y = 0;
        // Debug.Log(direction);

        Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
        // Debug.Log("Before Set: " + rotation.eulerAngles);
        // Debug.Log("After Set: " + rotation.eulerAngles);

        transform.rotation = rotation;
        transform.Rotate(0 , 90, 0); //little cheat to get the rotation right
    }


}
