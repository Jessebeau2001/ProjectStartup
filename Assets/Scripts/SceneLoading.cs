using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoading : MonoBehaviour
{
    public void LoadSceneString(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }
}
