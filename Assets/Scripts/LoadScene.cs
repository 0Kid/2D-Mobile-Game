using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void LoadButtonScene(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }
}
