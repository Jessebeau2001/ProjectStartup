using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendCharacter : MonoBehaviour
{
    [SerializeField] private GameObject child;
    private Vector3 stepSize;
    private Vector3 posHidden;
    private Vector3 posShown;
    private bool hidden = true;
    void Start() {
        child = transform.GetChild(0).gameObject;
        if (child != null) { //so the compiler wont complain about not being referenced
            stepSize = new Vector3(0, 0, transform.localScale.z);
        }
            
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            ToggleHide();
        }
    }

    public void UnHide() {
        child.transform.Translate(stepSize);
        hidden = false;
    }

    public void Hide() {
        child.transform.Translate(stepSize * -1);
        hidden = true;
    }

    public void ToggleHide() {
        if (hidden)
            UnHide();
        else
            Hide();
    }
}
