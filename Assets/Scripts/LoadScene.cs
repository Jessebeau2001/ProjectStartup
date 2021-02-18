using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoadScene : MonoBehaviour
{

    [SerializeField]
    private GameObject _loadingScreen;
    [SerializeField]
    private Slider _slider;
    [SerializeField]
    private TextMeshProUGUI _progressText;

    public void LoadARGame(int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        _loadingScreen.SetActive(true);

        while(!operation.isDone){
            float progress = Mathf.Clamp01(operation.progress / .9f);

            _slider.value = progress;
            _progressText.text = progress * 100f + "%";
            
            yield return null;
        }
    }
}
