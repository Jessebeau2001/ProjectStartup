using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClick : MonoBehaviour
{
    Animator squiddyAnim;
    public AudioSource palAudio;

    void Start()
    {
        squiddyAnim = gameObject.GetComponent<Animator>();
    }

    void OnMouseDown()
    {
        squiddyAnim.SetTrigger("Active");
        palAudio.Play();
    }

    void Update()
    {
        if (!Input.GetMouseButtonDown(0))
        {
            squiddyAnim.ResetTrigger("Active");
        }
    }
}
