using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Utils
{
    public static void LoadSceneStatic(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }
}
