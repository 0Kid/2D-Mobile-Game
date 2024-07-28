using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void LoadButtonScene(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }

    public void RetryGame()
    {
        Time.timeScale = 1f;
    }    

    public void ResumeGame()
    {
        Time.timeScale = 1f;
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
    }
}
