using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingManager : MonoBehaviour
{
    // Text UI untuk menampilkan pesan loading
    public Text loadingText; 
    // Nama scene yang akan diload
    public string sceneToLoad; 

    void Start()
    {
        StartCoroutine(LoadAsyncScene());
    }

    IEnumerator LoadAsyncScene()
    {
        // Memulai operasi loading secara asinkron
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneToLoad);

        // While loop sampai loading selesai
        while (!asyncLoad.isDone)
        {
            loadingText.text = "Loading... " + (asyncLoad.progress * 100) + "%";
            yield return null;
        }
    }
}
