using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyRandomColor : MonoBehaviour
{
    void Start()
    {
        Color32 color = new Color32((byte) Random.Range(0, 255), (byte) Random.Range(0, 255), (byte) Random.Range(0, 255), 255);
        // Color32 color = new Color32(244, 65, 89, 255);
        this.GetComponent<Renderer>().material.color = color;
        Debug.Log(color.r + " " + color.g + " " + color.b);
    }
}
