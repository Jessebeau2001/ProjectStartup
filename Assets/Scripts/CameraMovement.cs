using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float speed = 0.01f;
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.W)) {
            transform.Translate(new Vector3(0, 0, speed));
        }
        if(Input.GetKey(KeyCode.S)) {
            transform.Translate(new Vector3(0, 0, speed  * -1));
        }

        if(Input.GetKey(KeyCode.A)) {
            transform.Translate(new Vector3(speed * -1, 0, 0));
        }

        if(Input.GetKey(KeyCode.D)) {
            transform.Translate(new Vector3(speed, 0, 0));
        }

        if(Input.GetKey(KeyCode.E)) {
            transform.Rotate(0, speed * 20, 0);
        }

        if(Input.GetKey(KeyCode.Q)) {
            transform.Rotate(0, speed * -20, 0);
        }
    }
}
