using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendCharacter : MonoBehaviour
{
    [SerializeField] private GameObject wall;
    [SerializeField] private GameObject character;
    [SerializeField] private Animator animator;
    private Vector3 stepSize;
    private bool _hidden = true;
    void Start() {
        wall = transform.GetChild(0).gameObject;
        character = transform.GetChild(1).gameObject;
        animator = gameObject.GetComponent<Animator>();
        
        if (wall != null) { //so the compiler wont complain about not being referenced
            stepSize = new Vector3(0, 0, wall.transform.lossyScale.z);
        }
            
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            ToggleHide();
        }
    }

    public void ToggleHide() {
    _hidden = !_hidden;    
    animator.SetBool("Hidden", _hidden);
    }

    public void SetCharacterActive(bool isActive) {
        transform.GetChild(1).gameObject.SetActive(isActive);
    }

    public bool hidden {
        get { return _hidden; }
        set { 
            _hidden = value; 
            animator.SetBool("Hidden", _hidden);
        }
    }
}
