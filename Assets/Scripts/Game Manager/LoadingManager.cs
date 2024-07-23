using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingManager : MonoBehaviour
{
    // Referensi ke UI Slider
    public Slider loadingSlider;
    // Nama scene yang akan diload
    public string sceneToLoad; 

    void Start()
    {
        if (string.IsNullOrEmpty(sceneToLoad))
        {
            Debug.LogError("Scene to load is not set.");
            return;
        }
        
        StartCoroutine(LoadAsyncScene());
    }

    IEnumerator LoadAsyncScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneToLoad);

        while (!asyncLoad.isDone)
        {
            if (loadingSlider != null)
            {
                loadingSlider.value = asyncLoad.progress;
            }
            yield return null;
        }
    }
}
