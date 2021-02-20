using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public GameObject Panel0;
    public GameObject Panel1;
    public GameObject Panel2;

    public void SelectScene(int sceneNum)
    {
        SceneManager.LoadScene(sceneNum);
        Debug.Log(sceneNum);
    }

    public void SelectPanel(int panelNum)
    {
        if (panelNum == 0)
        {
            Panel0.SetActive(true);
            Panel1.SetActive(false);
            Panel2.SetActive(false);
        }
        if (panelNum == 1)
        {
            Panel0.SetActive(false);
            Panel1.SetActive(true);
            Panel2.SetActive(false);
        }
        if (panelNum == 2)
        {
            Panel0.SetActive(false);
            Panel1.SetActive(false);
            Panel2.SetActive(true);
        }
    }
}
