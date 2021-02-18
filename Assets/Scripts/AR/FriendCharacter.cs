using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendCharacter : MonoBehaviour
{
    public GameObject parentWall;
    private Vector3 movementModifier;
    private Vector3 posHidden;
    private Vector3 posShown;
    private bool isHidden = true;
    void Start()
    {
        if (parentWall != null){
            Debug.Log(parentWall.transform.localScale.z);
            movementModifier.Set(0, 0, parentWall.transform.localScale.z);

            posHidden = transform.position;
            posShown = transform.position + movementModifier;
        }
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (isHidden) {
                UnHide();
            } else {
                Hide();
            }
        }
    }

    public void UnHide() {
        // transform.Translate(movementModifier);
        transform.position = posShown;
        isHidden = false;
    }

    public void Hide() {
        transform.position = posHidden;
        isHidden = true;
    }
}
