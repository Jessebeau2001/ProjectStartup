using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendCharacter : MonoBehaviour
{
    [SerializeField] private GameObject characterObject;
    [SerializeField] private Animator wallAnimator;
    [SerializeField] private Animator charAnim;
    [SerializeField] private FaceCamera rotationScript;
    [SerializeField] private GameObject canvas;
    private bool _hidden = true;
    void Start() {
        characterObject = transform.GetChild(1).gameObject;
        wallAnimator = gameObject.GetComponent<Animator>();
        charAnim = characterObject.transform.GetChild(0).GetComponent<Animator>();
        rotationScript = gameObject.GetComponent<FaceCamera>();
        canvas = GameObject.Find("Canvas");
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            ToggleHide();
        }
    }

    public void ToggleHide() {
        _hidden = !_hidden;
        wallAnimator.SetBool("Hidden", _hidden);
        rotationScript.enabled = _hidden;
    
        EndGame();
    }

    public void WaveOnce() {
        charAnim.SetTrigger("Wave");
    }

    public void SetCharacterActive(bool isActive) {
        transform.GetChild(1).gameObject.SetActive(isActive);
    }

    public bool hidden {
        get { return _hidden; }
        set { 
            _hidden = value; 
            wallAnimator.SetBool("Hidden", _hidden);
        }
    }

    private void EndGame() {
        StartCoroutine(BackToMenu());
        canvas.GetComponent<Animator>().SetTrigger("FadeTopText");
        this.enabled = false; //To disable this script so it cant be interacted with again.
    }

    IEnumerator BackToMenu() {
        yield return new WaitForSeconds(5.0f);
        Utils.LoadSceneStatic("GamesScene");
    }
}
